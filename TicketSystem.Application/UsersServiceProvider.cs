using TicketSystem.Application.Services;
using TicketSystem.Domain;
using TicketSystem.Domain.User;
using TicketSystem.Infrastructure.Repositories;

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
        public readonly IUsersService UsersService;
        public UsersServiceProvider()
        {
            IUsersValidator validator = new UsersValidator();
            IRepository<User> repository = new UsersRepository();
            UsersService = new UsersService(validator, repository);
        }
    }
}
