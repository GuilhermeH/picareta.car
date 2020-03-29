using Core.picareta.DomainObjects;
using System;

namespace Admin.Picareta.Entidades
{
    public class MotivoReprovacao : Entity
    {
        public MotivoReprovacao(string motivo, Guid intencaoVendaId)
        {
            Motivo = motivo;
            IntencaoVendaId = intencaoVendaId;
        }

        public string Motivo { get; set; }
        public Guid IntencaoVendaId { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new MotivoReprovacaoValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
