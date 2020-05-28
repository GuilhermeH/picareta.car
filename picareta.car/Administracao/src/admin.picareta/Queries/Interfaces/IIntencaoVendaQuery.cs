using Admin.Picareta.Domain.Queries.Results;
using System.Collections.Generic;

namespace Admin.Picareta.Domain.Queries.Interfaces
{
    public interface IIntencaoVendaQuery
    {
        IEnumerable<IntencaoVendaQueryResult> GetIntencoesVendasParaAvaliacao();
    }
}
