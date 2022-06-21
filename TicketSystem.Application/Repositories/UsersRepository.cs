using System;
using System.Collections.Generic;
using System.Text;
using TicketSystem.Domain;
using TicketSystem.Domain.User;

namespace TicketSystem.Application.Repositories
{
    public class UsersRepository : IRepository<User>
    {
        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> Get()
        {
            return new List<User>
            { 
                new User(Role.RD,1),
                new User(Role.QA,2),
            };
        }

        public User Get(int entity)
        {
            throw new NotImplementedException();
        }
    }
}
