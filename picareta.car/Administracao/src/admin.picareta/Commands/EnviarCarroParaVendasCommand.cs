using Core.Picareta.DomainObjects;
using FluentValidation;
using System;

namespace Admin.Picareta.Commands
{
    public class EnviarCarroParaVendasCommand : Command
    {
        public EnviarCarroParaVendasCommand(Guid carroId, string cor, decimal valor, string modelo)
        {
            CarroId = carroId;
            Cor = cor;
            Valor = valor;
            Modelo = modelo;
        }

        public Guid CarroId { get; private set; }
        public string Cor { get; private set; }
        public decimal Valor { get; private set; }
        public string Modelo { get; private set; }
    }

    public class EnviarCarroParaVendasCommandValidation : AbstractValidator<EnviarCarroParaVendasCommand>
    {
        public EnviarCarroParaVendasCommandValidation()
        {
            RuleFor(c => c.CarroId)
                .NotEmpty()
                .WithMessage("Identificador do carro não pode ser vazio no command");

            RuleFor(c => c.Cor)
                .NotEmpty()
                .WithMessage("Cor do carro não pode ser vazia no command");

            RuleFor(c => c.Valor)
                .GreaterThan(0)
                .WithMessage("Valor do carro deve ser maior que 0 no command");

            RuleFor(c => c.Modelo)
                .NotEmpty()
                .WithMessage("Modelo do carro deve ser informado no command");
        }
    }
}
