using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.Domain.User
{
    public enum Role
    {
        QA,
        RD,
        PM,
        Administrator
    }

    public enum UsersValidationError
    {
        Success,
        PermissionDenied
    }
}
