using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Picareta.Domain.Commands.Validators
{
    public class AdicionarModeloCommandValidator : AbstractValidator<AdicionarModeloCommand>
    {
        public AdicionarModeloCommandValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Cor do carro não pode ser vazia no command");

            RuleFor(c => c.ValorMaximo)
                .GreaterThanOrEqualTo(c=> c.ValorMinimo)
                .WithMessage("Valor maximo deve ser maior que valor minimo");
        }
    }
}
