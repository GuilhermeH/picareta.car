using Admin.Picareta.ValueObjects;
using FluentValidation;

namespace Admin.Picareta.Entidades.Validators
{
    public class CarroValidator : AbstractValidator<Carro>
    {
        public CarroValidator()
        {
            RuleFor(c => c.Cor)
               .NotEmpty().WithMessage("A cor do carro não foi informada")
               .NotNull().WithMessage("A cor do carro não foi informada");

            RuleFor(c => c.Valor)
                .GreaterThan(0)
                .WithMessage("O valor do carro não foi informado");

            RuleFor(c => c.Modelo).Must(ModeloIsValid);
        }

        public bool ModeloIsValid(Modelo modelo)
        {
            return modelo.IsValid();
        }
    }
}
