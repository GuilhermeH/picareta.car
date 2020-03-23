using FluentValidation;

namespace Admin.Picareta.Entidades.Validators
{
    public class ModeloValidator : AbstractValidator<Modelo>
    {
        public ModeloValidator()
        {
            RuleFor(modelo => modelo.Nome).NotNull().NotEmpty().WithMessage("Nome não pode ser nulo");
            RuleFor(modelo => modelo.Nome).MaximumLength(25).WithMessage("Nome do Modele deve conter no máximo 25 caracteres");
            RuleFor(modelo => modelo.ValorMinimo).GreaterThan(0).WithMessage("Valor deve ser maior que zero");
            RuleFor(modelo => modelo.ValorMaximo).GreaterThan(modelo => modelo.ValorMinimo).WithMessage("Valor máximo não pode ser maior que o minimo");
        }
    }
}
