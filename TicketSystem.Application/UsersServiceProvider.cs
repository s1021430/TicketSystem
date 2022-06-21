using System;
using System.Collections.Generic;
using System.Text;
using TicketSystem.Application.Repositories;
using TicketSystem.Application.Services;
using TicketSystem.Domain;
using TicketSystem.Domain.User;

namespace TicketSystem.Application
{
    public class UsersServiceProvider
    {
        private static UsersServiceProvider? instance;
        public static UsersServiceProvider GetInstance()
        {
            return instance ??= new UsersServiceProvider();
        }

        public User CurrentUser;
        public IUsersService UsersService;
        public UsersServiceProvider()
        {
            IUsersValidator validator = new UsersValidator();
            IRepository<User> repository = new UsersRepository();
            UsersService = new UsersService(validator, repository);
        }
    }
}
