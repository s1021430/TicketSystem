namespace TicketSystem.Domain.User
{
    public interface IUsersService
    {
        public ServiceResult Create(User user);
        public ServiceResult Edit(User user);
        public ServiceResult Login(Role role, string userName);
    }
}
