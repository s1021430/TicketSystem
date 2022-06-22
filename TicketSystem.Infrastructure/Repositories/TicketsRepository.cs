using System;
using System.Collections.Generic;
using System.Linq;
using TicketSystem.Domain.Tickets;

namespace TicketSystem.Infrastructure.Repositories
{
    public class TicketsRepository : IRepository<Ticket>
    {
        private readonly List<Ticket> tickets;

        public TicketsRepository()
        {
            tickets = new List<Ticket>();
        }

        public void Add(Ticket entity)
        {
            entity.SetId(tickets.Count + 1);
            tickets.Add(entity);
        }

        public void Update(Ticket entity)
        {
            var target = tickets.SingleOrDefault(t => t.Id == entity.Id);
            if (target is null)
                throw new NullReferenceException("Can't find ticket to update.");
            target.Update(entity);
        }

        public void Delete(Ticket entity)
        {
            var target = tickets.SingleOrDefault(t => t.Id == entity.Id);
            if (target is null)
                throw new NullReferenceException("Can't find ticket to delete.");
            tickets.Remove(target);
        }

        public List<Ticket> Get()
        {
            return tickets;
        }

        public Ticket Get(int id)
        {
            var target = tickets.SingleOrDefault(t => t.Id == id);
            if (target is null)
                throw new NullReferenceException("Ticket not found!");
            return target;
        }
    }
}
