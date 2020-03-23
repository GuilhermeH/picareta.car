using Admin.Picareta.Entidades;
using Core.Picareta.DomainObjects;
using System.Collections.Generic;

namespace Admin.Picareta.Interfaces.Repositories
{
    public interface IIntencaoVendaRepository : IRepository<IntencaoVenda>
    {
        IEnumerable<IntencaoVenda> GetIntencoesVendasPendentesAvaliacao();
    }
}
