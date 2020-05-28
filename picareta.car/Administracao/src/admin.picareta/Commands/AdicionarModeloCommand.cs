using Admin.Picareta.Domain.Commands.Validators;
using Core.Picareta.DomainObjects;

namespace Admin.Picareta.Domain.Commands
{
    public class AdicionarModeloCommand : Command
    {
        public AdicionarModeloCommand(string nome, decimal valorMinimo, decimal valorMaximo)
        {
            Nome = nome;
            ValorMinimo = valorMinimo;
            ValorMaximo = valorMaximo;
        }

        public string Nome { get; private set; }
        public decimal ValorMinimo { get; private set; }
        public decimal ValorMaximo { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new AdicionarModeloCommandValidator().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
