using Core.Picareta.DomainObjects;
using System;

namespace Admin.Picareta.Domain.Queries.Results
{
    public class IntencaoVendaQueryResult : QueryResult
    {
        public IntencaoVendaQueryResult(string modeloCarro, string corCarro, decimal valorCarro, Guid intencaoVendaId)
        {
            ModeloCarro = modeloCarro;
            CorCarro = corCarro;
            ValorCarro = valorCarro;
            IntencaoVendaId = intencaoVendaId;
        }

        public string ModeloCarro { get; private set; }
        public string CorCarro { get; private set; }
        public decimal ValorCarro { get; private set; }
        public Guid IntencaoVendaId { get; private set; }

    }
}
