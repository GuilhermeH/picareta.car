using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;

namespace Core.Picareta.DomainObjects
{
    public class Command : IRequest<bool>
    {
        public Command()
        {
            TimesTamp = DateTime.Now;
        }
        public DateTime TimesTamp { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid(ValidationResult validationResult)
        {
            return validationResult.IsValid;
        }
    }
}
