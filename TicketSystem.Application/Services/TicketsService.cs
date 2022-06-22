using System;
using System.Collections.Generic;
using TicketSystem.Domain;
using TicketSystem.Domain.Tickets;
using TicketSystem.Domain.User;
using TicketSystem.Infrastructure.Repositories;

namespace TicketSystem.Application.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly ITicketsValidator validator;
        private readonly IRepository<Ticket> repository;
        public TicketsService(ITicketsValidator validator, IRepository<Ticket> repository)
        {
            this.validator = validator;
            this.repository = repository;
        }

        public ServiceResult Create(Ticket ticket)
        {
            try
            {
                var validateResult = validator.ValidateTicketCreate(ticket);
                if(validateResult == TicketsValidationError.Success)
                    repository.Add(ticket);
                return validateResult == TicketsValidationError.Success
                    ? new ServiceResult(true, "Ticket created!")
                    : new ServiceResult(false, $"Ticket create failed({validateResult})!");
            }
            catch (Exception e)
            {
                return new ServiceResult(false, e.Message);
            }
        }

        public ServiceResult Resolve(int id, User assignee)
        {
            try
            {
                var resolvedTicket = repository.Get(id).ShallowCopy();
                resolvedTicket.Assignee = assignee;
                var validateResult = validator.ValidateTicketResolve(resolvedTicket);
                if (validateResult != TicketsValidationError.Success)
                    return new ServiceResult(false, $"Ticket resolve failed({validateResult})!");
                resolvedTicket.Status = TicketsStatus.Resolved;
                repository.Update(resolvedTicket);
                return new ServiceResult(true, "Ticket resolved!");
            }
            catch (Exception e)
            {
                return new ServiceResult(false, e.Message);
            }
        }

        public ServiceResult Edit(Ticket selectedTicket)
        {
            var validateResult = validator.ValidateTicketEdit(selectedTicket);
            if (validateResult != TicketsValidationError.Success)
                return new ServiceResult(false, $"Ticket edit failed({validateResult})!");
            repository.Update(selectedTicket);
            return new ServiceResult(true, "Ticket edited!");
        }

        public List<Ticket> GeTickets()
        {
            return repository.Get();
        }

        public Ticket GeTicket(int id)
        {
            return repository.Get(id);
        }

        public ServiceResult Delete(Ticket selectedTicket)
        {
            try
            {
                repository.Delete(selectedTicket);
                return new ServiceResult(true, "Ticket deleted!");
            }
            catch (Exception e)
            {
                return new ServiceResult(false, e.Message);
            }
        }
    }
}
