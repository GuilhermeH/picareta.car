using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Admin.Picareta.Commands.Handlers
{
    //TODO: Resolver injeção de dependencia depois quando criado startup
    public class CarroParaVendasHandler : IRequestHandler<EnviarCarroParaVendasCommand, bool>
    {
        public Task<bool> Handle(EnviarCarroParaVendasCommand request, CancellationToken cancellationToken)
        {
            //será enviado para o contexto de vendas o carro que ficará lá disponível para visualização
            //objeto a ser definido
            throw new System.NotImplementedException();
        }
    }
}
