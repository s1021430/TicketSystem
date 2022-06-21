using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.Domain.SpecificationTemplate
{
    public class Specification<TErrorCode, TCandidate>
    {
        private readonly ISpecification<TCandidate> specification;
        public TErrorCode ErrorCode { get; }

        public Specification(TErrorCode errorCode, ISpecification<TCandidate> specification)
        {
            ErrorCode = errorCode;
            this.specification = specification;
        }

        public bool Validate(TCandidate candidate)
        {
            return specification.IsSatisfiedBy(candidate);
        }
    }
}
