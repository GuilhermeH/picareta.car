using FluentValidation;

namespace Admin.Picareta.Commands.Validators
{
    public class AdicionarIntencaoVendaCommandValidator : AbstractValidator<AdicionarIntencaoVendaCommand>
    {
        public AdicionarIntencaoVendaCommandValidator()
        {
            RuleFor(c => c.Cor)
                .NotEmpty()
                .WithMessage("Cor do carro não pode ser vazia no command");

            RuleFor(c => c.Valor)
                .GreaterThan(0)
                .WithMessage("Valor do carro deve ser maior que 0 no command");

            RuleFor(c => c.ModeloId)
                .NotEmpty()
                .WithMessage("Modelo do carro deve ser informado no command");
        }
    }
}
