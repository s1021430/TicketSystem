using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.Domain.SpecificationTemplate
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
        ISpecification<T> And(ISpecification<T> specification);
        ISpecification<T> Or(ISpecification<T> specification);
        ISpecification<T> Not();
    }
}
