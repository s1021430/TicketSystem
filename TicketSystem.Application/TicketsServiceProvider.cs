using System;
using System.Collections.Generic;
using System.Text;
using TicketSystem.Application.Repositories;
using TicketSystem.Application.Services;
using TicketSystem.Domain.Tickets;

namespace TicketSystem.Application
{
    public class TicketsServiceProvider
    {
        private static TicketsServiceProvider? instance;
        public static TicketsServiceProvider GetInstance()
        {
            return instance ??= new TicketsServiceProvider();
        }

        public ITicketsService TicketsService;
        public TicketsServiceProvider()
        {
            var validator = new TicketsValidator();
            var repository = new TicketsRepository();
            TicketsService = new TicketsService(validator, repository);
        }
    }
}
