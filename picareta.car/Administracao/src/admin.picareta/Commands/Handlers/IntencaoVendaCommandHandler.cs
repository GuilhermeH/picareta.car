using Admin.Picareta.Domain.Interfaces.Repositories;
using Admin.Picareta.Entidades;
using Admin.Picareta.Interfaces.Repositories;
using Admin.Picareta.ValueObjects;
using Core.Picareta.Comunication;
using Core.Picareta.DomainObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Admin.Picareta.Commands.Handlers
{
    //TODO: Resolver injeção de dependencia depois quando criado startup
    public class IntencaoVendaCommandHandler : CommandHandlerBase, IRequestHandler<AdicionarIntencaoVendaCommand, bool>
    {
        private readonly IIntencaoVendaRepository _intencaoVendaRepository;
        private readonly IModeloRepository _modeloRepository;
        private readonly IComunication _comunication;

        public IntencaoVendaCommandHandler(IIntencaoVendaRepository intencaoVendaRepository,
            IModeloRepository modeloRepository,
            IComunication comunication)
            : base(comunication)
        {
            _intencaoVendaRepository = intencaoVendaRepository;
            _modeloRepository = modeloRepository;
            _comunication = comunication;
        }
        public async Task<bool> Handle(AdicionarIntencaoVendaCommand command, CancellationToken cancellationToken)
        {
            if (!IsValid(command))
            {
                return false;
            }
            var modelo = _modeloRepository.GetModelo(command.ModeloId);

            var carro = new Carro(command.Cor, command.Valor, modelo);
            if (carro.IsValid() && modelo.IsValid())
            {
                var intencaoVenda = new IntencaoVenda(carro, modelo);
                _intencaoVendaRepository.AddIntencaoVenda(intencaoVenda);
            }
            else
            {
                //TODO: repensar isso aqui
                foreach (var error in carro.ValidationResult.Errors)
                {
                    await _comunication.PublicarDomainNotification(new DomainNotification(error.PropertyName, error.ErrorMessage));
                }

                foreach (var error in modelo.ValidationResult.Errors)
                {
                    await _comunication.PublicarDomainNotification(new DomainNotification(error.PropertyName, error.ErrorMessage));
                }

            }

            return false;
        }
    }
}
