namespace TicketSystem.Domain.Tickets
{
    public enum Priority
    {

    }

    public enum Severity
    {

    }

    public enum TicketType
    {
        Bug,
        FeatureRequest,
        TestCase
    }

    public enum TicketsValidationError
    {
        Success,
        PermissionDenied,
        SummaryEmpty,
        DescriptionEmpty,
        OnlyOpenedCanBeResolved
    }

    public enum TicketsStatus
    {
        Opened,
        Resolved
    }
}
