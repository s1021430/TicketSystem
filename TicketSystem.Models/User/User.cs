namespace TicketSystem.Domain.User
{
    public class User
    {
        public Role Role;
        public int Id;
        public string Name => $"{Role}_{Id}";
        public User(Role role, int id)
        {
            Role = role;
            Id = id;
        }
    }
}
