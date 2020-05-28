using Admin.Picareta.Domain.Queries.Interfaces;
using Admin.Picareta.Domain.Queries.Results;
using Admin.Picareta.Interfaces.Repositories;
using System.Collections.Generic;

namespace Admin.Picareta.Application.Queries
{
    public class IntencaoVendaQuery : IIntencaoVendaQuery
    {
        private readonly IIntencaoVendaRepository _intencaoVendaRepository;

        public IntencaoVendaQuery(IIntencaoVendaRepository intencaoVendaRepository)
        {
            _intencaoVendaRepository = intencaoVendaRepository;
        }

        public IEnumerable<IntencaoVendaQueryResult> GetIntencoesVendasParaAvaliacao()
        {
            var intencoesPendentesResult = new List<IntencaoVendaQueryResult>();
            var intencoesVenda = _intencaoVendaRepository.GetIntencoesVendasPendentesAvaliacao();
            foreach (var intencaoVenda in intencoesVenda)
            {
                intencoesPendentesResult.Add(new IntencaoVendaQueryResult(intencaoVenda.Carro.Modelo.Nome, intencaoVenda.Carro.Cor, intencaoVenda.Carro.Valor, intencaoVenda.Id));
            }

            return intencoesPendentesResult;
        }
    }
}
