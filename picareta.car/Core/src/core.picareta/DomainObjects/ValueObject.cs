using FluentValidation.Results;
using System;

namespace Core.Picareta.DomainObjects
{
    public abstract class ValueObject
    {
        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
