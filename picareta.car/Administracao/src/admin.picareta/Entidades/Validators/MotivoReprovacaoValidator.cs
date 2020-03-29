using Admin.Picareta.Entidades;
using FluentValidation;

public class MotivoReprovacaoValidator : AbstractValidator<MotivoReprovacao>
{
    public MotivoReprovacaoValidator()
    {
        RuleFor(m => m.Motivo)
            .NotEmpty().WithMessage("O motivo de reprovação não foi informado")
            .NotNull().WithMessage("O motivo de reprovação não foi informado");

        RuleFor(m => m.IntencaoVendaId)
            .NotEmpty().WithMessage("A intenção de venda não foi informada")
            .NotNull().WithMessage("A intenção de venda não foi informada");
    }
}