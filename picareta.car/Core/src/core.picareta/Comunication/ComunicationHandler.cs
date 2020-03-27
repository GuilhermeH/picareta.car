using Core.Picareta.DomainObjects;
using MediatR;
using System.Threading.Tasks;

namespace Core.Picareta.Comunication
{
    public class ComunicationHandler : IComunication
    {
        private readonly IMediator _mediator;
        public ComunicationHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public Task PublicarEvento<T>(T evento) where T : Event
        {
            return _mediator.Publish(evento);
        }
    }
}
