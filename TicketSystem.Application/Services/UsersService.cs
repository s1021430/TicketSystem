using System;
using System.Collections.Generic;
using System.Linq;
using TicketSystem.Domain;
using TicketSystem.Domain.User;
using TicketSystem.Infrastructure.Repositories;

namespace TicketSystem.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersValidator validator;
        private readonly IRepository<User> repository;
        private readonly List<User> users;
        public UsersService(IUsersValidator validator, IRepository<User> repository)
        {
            this.validator = validator;
            this.repository = repository;
            users = repository.Get();
        }


        public ServiceResult Create(User user)
        {
            var validateResult = validator.Validate(user);
            repository.Add(user);
            return validateResult == UsersValidationError.Success
                ? new ServiceResult(true, "User created!")
                : new ServiceResult(false, $"User create failed({validateResult})!");
        }

        public ServiceResult Edit(User user)
        {
            var validateResult = validator.Validate(user);
            repository.Update(user);
            return validateResult == UsersValidationError.Success
                ? new ServiceResult(true, "User created!")
                : new ServiceResult(false, $"User create failed({validateResult})!");
        }

        public ServiceResult Login(Role role, string userName)
        {
            var targetUser = users.SingleOrDefault(u => u.Role == role);
            if (targetUser == null) return new ServiceResult(false, "User not found!");
            UsersServiceProvider.GetInstance().CurrentUser = targetUser;
            return new ServiceResult(true, "Login Success!");
        }
    }
}
