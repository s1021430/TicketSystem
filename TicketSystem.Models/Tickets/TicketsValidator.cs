using System.Collections.Generic;
using TicketSystem.Domain.SpecificationTemplate;

namespace TicketSystem.Domain.Tickets
{
    public interface ITicketsValidator
    {
        public TicketsValidationError ValidateTicketCreate(Ticket ticket);
        public TicketsValidationError ValidateTicketResolve(Ticket ticket);
        public TicketsValidationError ValidateTicketEdit(Ticket ticket);
    }

    public class TicketsValidator : ITicketsValidator
    {
        private readonly List<Specification<TicketsValidationError, Ticket>> ticketsCreateRules;
        private readonly List<Specification<TicketsValidationError, Ticket>> ticketsEditRules;
        private readonly List<Specification<TicketsValidationError, Ticket>> ticketsResolveRules;

        public TicketsValidator()
        {
            ticketsCreateRules = new List<Specification<TicketsValidationError, Ticket>>
            {
                new(TicketsValidationError.PermissionDenied, new TicketEditPermissionRule()),
                new(TicketsValidationError.SummaryEmpty, new SummaryRule()),
                new(TicketsValidationError.DescriptionEmpty, new DescriptionRule()),
            };
            ticketsEditRules = new List<Specification<TicketsValidationError, Ticket>>
            {
                new(TicketsValidationError.PermissionDenied, new TicketEditPermissionRule()),
                new(TicketsValidationError.SummaryEmpty, new SummaryRule()),
                new(TicketsValidationError.DescriptionEmpty, new DescriptionRule()),
            };
            ticketsResolveRules = new List<Specification<TicketsValidationError, Ticket>>
            {
                new(TicketsValidationError.PermissionDenied, new TicketResolvePermissionRule()),
                new(TicketsValidationError.OnlyOpenedCanBeResolved, new TicketResolveStatusRule()),
            };
        }

        public TicketsValidationError ValidateTicketCreate(Ticket candidate)
        {
            return Validate(ticketsCreateRules, candidate);
        }

        public TicketsValidationError ValidateTicketResolve(Ticket candidate)
        {
            return Validate(ticketsResolveRules, candidate);
        }

        public TicketsValidationError ValidateTicketEdit(Ticket candidate)
        {
            return Validate(ticketsEditRules, candidate);
        }

        private static TicketsValidationError Validate(List<Specification<TicketsValidationError, Ticket>> rules,
            Ticket candidate)
        {
            foreach (var rule in rules)
            {
                if (!rule.Validate(candidate))
                    return rule.ErrorCode;
            }

            return TicketsValidationError.Success;
        }
    }
}