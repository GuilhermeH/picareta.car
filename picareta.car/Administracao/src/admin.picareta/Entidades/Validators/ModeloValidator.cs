using FluentValidation;

namespace Admin.Picareta.Entidades.Validators
{
    public class ModeloValidator : AbstractValidator<Modelo>
    {
        public ModeloValidator()
        {
            RuleFor(modelo => modelo.Nome).NotNull().NotEmpty().WithMessage("Nome não pode ser nulo");
            RuleFor(modelo => modelo.Nome).MaximumLength(25).WithMessage("Nome do Modele deve conter no máximo 25 caracteres");
            RuleFor(modelo => modelo).Custom((modelo, context) => {
                if (modelo.ValorMaximo < modelo.ValorMinimo)
                {
                    context.AddFailure("Valor máximo deve ser maior que o minimo");
                }
            });
        }
    }
}
