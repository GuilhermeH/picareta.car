using Admin.Picareta.Domain.Interfaces.Repositories;
using Admin.Picareta.Entidades;
using Core.Picareta.Comunication;
using Core.Picareta.DomainObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Admin.Picareta.Domain.Commands.Handlers
{
    public class ModeloCommandHandler : CommandHandlerBase, IRequestHandler<AdicionarModeloCommand, bool>
    {
        private readonly IComunication _comunication;
        private readonly IModeloRepository _modeloRepository;
        public ModeloCommandHandler(IModeloRepository modeloRepository, IComunication comunication) : base(comunication)
        {
            _comunication = comunication;
            _modeloRepository = modeloRepository;
        }

        public async Task<bool> Handle(AdicionarModeloCommand adicionarModeloCommand, CancellationToken cancellationToken)
        {
            if (!IsValid(adicionarModeloCommand))
            {
                return false;
            }

            var modelo = new Modelo(adicionarModeloCommand.Nome, adicionarModeloCommand.ValorMinimo, adicionarModeloCommand.ValorMaximo);
            if (modelo.IsValid())
            {
                _modeloRepository.AddModelo(modelo);
                _modeloRepository.Commit();

                return true;
            }

            foreach (var erro in modelo.ValidationResult.Errors)
            {
                await _comunication.PublicarDomainNotification(new DomainNotification(erro.ErrorCode, erro.ErrorMessage));
            }

            return false;
        }
    }
}
