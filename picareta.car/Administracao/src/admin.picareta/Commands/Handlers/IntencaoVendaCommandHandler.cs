using Admin.Picareta.Entidades;
using Admin.Picareta.Interfaces.Repositories;
using Admin.Picareta.ValueObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Admin.Picareta.Commands.Handlers
{
    //TODO: Resolver injeção de dependencia depois quando criado startup
    public class IntencaoVendaCommandHandler : IRequestHandler<AdicionarIntencaoVendaCommand, bool>
    {
        private readonly IIntencaoVendaRepository _intencaoVendaRepository;

        public IntencaoVendaCommandHandler(IIntencaoVendaRepository intencaoVendaRepository)
        {
            _intencaoVendaRepository = intencaoVendaRepository;
        }
        public async Task<bool> Handle(AdicionarIntencaoVendaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                return false;
            }
            var modelo = _intencaoVendaRepository.GetModelo(command.ModeloId);

            var carro = new Carro(command.Cor, command.Valor, modelo);
            if (carro.IsValid() && modelo.IsValid())
            {
                new IntencaoVenda(carro, modelo);
            }
            
            return false;
        }
    }
}
