using CommunityToolkit.Mvvm.ComponentModel;
using TicketSystem.Domain.Tickets;

namespace TicketSystem.Presentation.ViewModels
{
    public class TicketViewModel : ObservableObject
    {
        public static explicit operator TicketViewModel(Ticket data)
        {
            return new TicketViewModel(data);
        }
        public static implicit operator Ticket(TicketViewModel viewModel)
        {
            var ticket = new Ticket(viewModel.Type)
            {
                Status = viewModel.Status,
                Summary = viewModel.Summary,
                Description = viewModel.Description,
                Creator = viewModel.Creator,
                Assignee = viewModel.Assignee
            };
            ticket.SetId(viewModel.Id);
            return ticket;
        }
        public int Id { get; }

        public TicketViewModel(Ticket data)
        {
            Id = data.Id;
            Name = data.Name;
            Status = data.Status;
            Type = data.Type;
            Summary = data.Summary;
            Description = data.Description;
            Creator = (UserViewModel)data.Creator;
            if(data.Assignee != null)
                Assignee = (UserViewModel)data.Assignee;
        }

        public TicketViewModel(string summary, string description, UserViewModel creator)
        {
            Summary = summary;
            Description = description;
            Creator = creator;
        }

        private TicketsStatus status;
        public TicketsStatus Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }

        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string summary;
        public string Summary
        {
            get => summary;
            set => SetProperty(ref summary, value);
        }

        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public TicketType Type { get; } = TicketType.Bug;
        public UserViewModel Creator { get; set; }
        public UserViewModel Assignee { get; set; }
    }
}
