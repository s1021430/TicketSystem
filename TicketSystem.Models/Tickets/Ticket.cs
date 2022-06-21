using System;
using System.Runtime.Serialization;

namespace TicketSystem.Domain.Tickets
{
    public class Ticket
    {
        public int Id { get; private set; }
        public string Name => Id <= 0 ? string.Empty : $"Ticket-{Id}";
        public TicketType Type;
        public TicketsStatus Status = TicketsStatus.Opened;
        public User.User Creator;
        public User.User Assignee;
        public string Summary;
        public string Description;
        public Severity Severity;
        public Priority Priority;
        public Ticket(TicketType type)
        {
            Type = type;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void Update(Ticket entity)
        {
            Id = entity.Id;
            Type = entity.Type;
            Status = entity.Status;
            Summary = entity.Summary;
            Creator = entity.Creator;
            Assignee = entity.Assignee;
            Description = entity.Description;
            Severity = entity.Severity;
            Priority = entity.Priority;
        }
        public Ticket ShallowCopy()
        {
            return (Ticket)MemberwiseClone();
        }
    }
}
