using System;

namespace TicketSystem.Domain.SpecificationTemplate
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T candidate);

        public ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }
        public ISpecification<T> Or(ISpecification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }
        public ISpecification<T> Not()
        {
            return new NotSpecification<T>(this);
        }
    }

    public class AndSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> left;
        private readonly ISpecification<T> right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return left.IsSatisfiedBy(candidate)
                && right.IsSatisfiedBy(candidate);
        }
    }
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> left;
        private readonly ISpecification<T> right;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return left.IsSatisfiedBy(candidate)
                || right.IsSatisfiedBy(candidate);
        }
    }

    public class NotSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> spec;

        public NotSpecification(ISpecification<T> spec)
        {
            this.spec = spec;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return !spec.IsSatisfiedBy(candidate);
        }
    }

    public class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        private readonly Func<T, bool> expression;
        public ExpressionSpecification(Func<T, bool> expression)
        {
            this.expression = expression;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return expression(candidate);
        }
    }
}
