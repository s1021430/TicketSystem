using System.Collections.Generic;
using TicketSystem.Domain.SpecificationTemplate;

namespace TicketSystem.Domain.User
{
    public interface IUsersValidator
    {
        public UsersValidationError Validate(User user);
    }

    public class UsersValidator : IUsersValidator
    {
        private readonly List<Specification<UsersValidationError, User>> usersEditRules;

        public UsersValidator()
        {
            usersEditRules = new List<Specification<UsersValidationError, User>>
            {
                new(UsersValidationError.PermissionDenied, new UsersEditRule()),
            };

        }

        public UsersValidationError Validate(User user)
        {
            foreach (var rule in usersEditRules)
            {
                if (!rule.Validate(user))
                    return rule.ErrorCode;
            }

            return UsersValidationError.Success;
        }
    }
}
