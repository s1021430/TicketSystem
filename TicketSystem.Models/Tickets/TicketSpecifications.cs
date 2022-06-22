using System;
using TicketSystem.Domain.SpecificationTemplate;
using TicketSystem.Domain.User;

namespace TicketSystem.Domain.Tickets
{
    public class TicketEditPermissionRule : CompositeSpecification<Ticket>
    {
        public override bool IsSatisfiedBy(Ticket ticket)
        {
            var creator = ticket.Creator;
            if (creator is null)
                throw new ArgumentNullException(nameof(creator));
            switch (ticket.Type)
            {
                case TicketType.Bug:
                case TicketType.TestCase:
                    return creator.Role == Role.QA;
                case TicketType.FeatureRequest:
                    return creator.Role == Role.PM;
                default:
                    throw new ArgumentOutOfRangeException($"Ticket type({ticket.Type}) undefined.");
            }
        }
    }

    public class SummaryRule : CompositeSpecification<Ticket>
    {
        public override bool IsSatisfiedBy(Ticket ticket)
        {
            return !string.IsNullOrWhiteSpace(ticket.Summary);
        }
    }

    public class DescriptionRule : CompositeSpecification<Ticket>
    {
        public override bool IsSatisfiedBy(Ticket ticket)
        {
            return !string.IsNullOrWhiteSpace(ticket.Description);
        }
    }

    public class TicketResolvePermissionRule : CompositeSpecification<Ticket>
    {
        public override bool IsSatisfiedBy(Ticket ticket)
        {
            var assignee = ticket.Assignee;
            if (assignee is null)
                throw new ArgumentNullException(nameof(assignee));
            switch (ticket.Type)
            {
                case TicketType.Bug:
                case TicketType.FeatureRequest:
                    return assignee.Role == Role.RD;
                case TicketType.TestCase:
                    return assignee.Role == Role.QA;
                default:
                    throw new ArgumentOutOfRangeException($"Ticket type({ticket.Type}) undefined.");
            }
        }
    }

    public class TicketResolveStatusRule : CompositeSpecification<Ticket>
    {
        public override bool IsSatisfiedBy(Ticket ticket)
        {
            return ticket.Status switch
            {
                TicketsStatus.Opened => true,
                TicketsStatus.Resolved => false,
                _ => throw new ArgumentOutOfRangeException($"Ticket status({ticket.Status}) undefined.")
            };
        }
    }
}
