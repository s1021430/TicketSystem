using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using TicketSystem.Application;
using TicketSystem.Domain.Tickets;
using TicketSystem.Domain.User;
using TicketSystem.Presentation.ViewModels;

namespace TicketSystem.Presentation
{
    public class MainViewModel : ObservableRecipient
    {
        private readonly IUsersService usersService = UsersServiceProvider.GetInstance().UsersService;
        private readonly ITicketsService ticketsService = TicketsServiceProvider.GetInstance().TicketsService;
        private UserViewModel currentUser;

        private bool bugResolveEnabled;
        public bool BugResolveEnabled
        {
            get => bugResolveEnabled;
            set => SetProperty(ref bugResolveEnabled, value, true);
        }

        private bool bugCreateEnabled;
        public bool BugCreateEnabled
        {
            get => bugCreateEnabled;
            set => SetProperty(ref bugCreateEnabled, value, true);
        }

        private string message;
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value, true);
        }

        private System.Windows.Controls.UserControl dialogContent;
        public System.Windows.Controls.UserControl DialogContent
        {
            get => dialogContent;
            set => SetProperty(ref dialogContent, value);
        }

        private bool isDialogOpen;
        public bool IsDialogOpen
        {
            get => isDialogOpen;
            set => SetProperty(ref isDialogOpen, value);
        }

        private Role selectedRole;
        public Role SelectedRole
        {
            get => selectedRole;
            set => SetProperty(ref selectedRole, value, true);
        }

        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value, true);
        }

        private TicketViewModel? selectedTicket;
        public TicketViewModel? SelectedTicket
        {
            get => selectedTicket;
            set => SetProperty(ref selectedTicket, value, true);
        }

        private ObservableCollection<TicketViewModel> tickets;
        public ObservableCollection<TicketViewModel> Tickets
        {
            get => tickets;
            set => SetProperty(ref tickets, value, true);
        }

        private string bugSummary;
        public string BugSummary
        {
            get => bugSummary;
            set => SetProperty(ref bugSummary, value, true);
        }

        private string bugDescription;
        public string BugDescription
        {
            get => bugDescription;
            set => SetProperty(ref bugDescription, value, true);
        }
        public RelayCommand OpenLoginDialogCommand { get; }
        public RelayCommand LoginCommand { get; }
        public RelayCommand ResolveCommand { get; }
        public RelayCommand ReportCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand EditCommand { get; }
        public MainViewModel()
        {
            OpenLoginDialogCommand = new RelayCommand(OpenLoginDialog);
            LoginCommand = new RelayCommand(Login);
            ResolveCommand = new RelayCommand(Resolve);
            ReportCommand = new RelayCommand(Report);
            DeleteCommand = new RelayCommand(Delete);
            EditCommand = new RelayCommand(Edit);
            DialogContent = new LoginView(this);
            IsDialogOpen = true;
            UpdateUi();
        }

        private void Edit()
        {
            if (SelectedTicket == null)
            {
                Message = "Must select ticket to edit.";
                return;
            }
            var editResult = ticketsService.Edit(SelectedTicket);
            Message = editResult.Message;
            if (!editResult.Success) 
                SelectedTicket = (TicketViewModel)ticketsService.GeTicket(SelectedTicket.Id);

        }

        private void Delete()
        {
            if (SelectedTicket == null)
            {
                Message = "Must select ticket to delete.";
                return;
            }
            var deleteResult = ticketsService.Delete(SelectedTicket);
            Message = deleteResult.Message;
            if (!deleteResult.Success) return;
            Tickets = new ObservableCollection<TicketViewModel>(ticketsService.GeTickets().Select(_ => (TicketViewModel)_));
            SelectedTicket = Tickets.Last();
        }

        private void OpenLoginDialog()
        {
            IsDialogOpen = true;
        }

        private void Report()
        {
            var ticket = new TicketViewModel(BugSummary, BugDescription, currentUser);
            var reportResult = ticketsService.Create(ticket);
            Message = reportResult.Message;
            if (!reportResult.Success) return;
            IsDialogOpen = false;
            Tickets = new ObservableCollection<TicketViewModel>(ticketsService.GeTickets().Select(_ => (TicketViewModel)_));
            SelectedTicket = Tickets.Last();
        }

        private void Resolve()
        {
            if (SelectedTicket == null)
            {
                Message = "Must select ticket to resolve.";
                return;
            }
            var resolveResult = ticketsService.Resolve(SelectedTicket.Id, currentUser);
            Message = resolveResult.Message;
            if (!resolveResult.Success) return;
            Tickets = new ObservableCollection<TicketViewModel>(ticketsService.GeTickets().Select(_ => (TicketViewModel)_));
            SelectedTicket = Tickets.Last();
        }

        private void Login()
        {
            var loginResult = usersService.Login(SelectedRole, Name);
            Message = loginResult.Message;
            if (!loginResult.Success) return;
            IsDialogOpen = false;
            currentUser = (UserViewModel)UsersServiceProvider.GetInstance().CurrentUser;
            UpdateUi();
        }

        private void UpdateUi()
        {
            switch (SelectedRole)
            {
                case Role.QA:
                    BugCreateEnabled = true;
                    BugResolveEnabled = false;
                    break;
                case Role.RD:
                    BugCreateEnabled = false;
                    BugResolveEnabled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
