using TicketSystem.Application.Services;
using TicketSystem.Domain.Tickets;
using TicketSystem.Infrastructure.Repositories;

namespace TicketSystem.Application
{
    public class TicketsServiceProvider
    {
        private static TicketsServiceProvider? instance;
        public static TicketsServiceProvider GetInstance()
        {
            return instance ??= new TicketsServiceProvider();
        }

        public readonly ITicketsService TicketsService;
        public TicketsServiceProvider()
        {
            var validator = new TicketsValidator();
            var repository = new TicketsRepository();
            TicketsService = new TicketsService(validator, repository);
        }
    }
}
