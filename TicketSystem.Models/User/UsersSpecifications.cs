using System;
using System.Collections.Generic;
using System.Text;
using TicketSystem.Domain.SpecificationTemplate;

namespace TicketSystem.Domain.User
{
    public class UsersEditRule : CompositeSpecification<User>
    {
        public override bool IsSatisfiedBy(User user)
        {
            return user.Role == Role.Administrator;
        }
    }
}
