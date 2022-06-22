using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.Domain.Tickets
{
    public interface ITicketsService
    {
        public ServiceResult Create(Ticket ticket);
        public ServiceResult Resolve(int id, User.User assignee);
        public ServiceResult Edit(Ticket selectedTicket);
        public List<Ticket> GeTickets();
        public Ticket GeTicket(int id);
        public ServiceResult Delete(Ticket selectedTicket);
    }
}
