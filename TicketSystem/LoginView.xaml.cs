using System.Windows.Controls;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace TicketSystem.Presentation.Login
{
    /// <summary>
    /// LoginView.xaml 的互動邏輯
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView(ObservableRecipient dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}
