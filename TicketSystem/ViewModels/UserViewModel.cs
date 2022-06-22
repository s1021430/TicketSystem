using System;
using System.Collections.Generic;
using System.Text;
using TicketSystem.Domain.User;

namespace TicketSystem.Presentation.ViewModels
{
    public class UserViewModel
    {
        public static explicit operator UserViewModel(User data)
        {
            return new UserViewModel(data);
        }

        public static implicit operator User(UserViewModel? viewModel)
        {
            return (viewModel is null ? null : new User(viewModel.Role, viewModel.Id))!;
        }

        public Role Role;
        public int Id;
        public UserViewModel(User user)
        {
            Role = user.Role;
            Id = user.Id;
        }
    }
}
