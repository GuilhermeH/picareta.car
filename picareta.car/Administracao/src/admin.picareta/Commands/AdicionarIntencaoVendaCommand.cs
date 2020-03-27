using Admin.Picareta.Commands.Validators;
using Core.Picareta.DomainObjects;
using System;

namespace Admin.Picareta.Commands
{
    public class AdicionarIntencaoVendaCommand : Command
    {
        public AdicionarIntencaoVendaCommand(string cor, decimal valor, Guid modeloId)
        {
            Cor = cor;
            Valor = valor;
            ModeloId = modeloId;
        }

        public Guid ModeloId { get; private set; }
        public string Cor { get; private set; }
        public decimal Valor { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new AdicionarIntencaoVendaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
