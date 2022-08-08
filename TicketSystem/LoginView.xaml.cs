using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TicketSystem.Presentation
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
