using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.Domain.Tickets
{
    public interface ITicketsService
    {
        public ServiceResult Create(Ticket ticket);
        public ServiceResult Resolve(int id, User.User assignee);
        public ServiceResult Edit(int id);
        public List<Ticket> GeTickets();
    }
}
