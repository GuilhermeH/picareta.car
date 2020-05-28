using Admin.Picareta.Entidades;
using System;
using System.Linq.Expressions;

namespace Admin.Picareta.Domain.Queries.Specifications
{
    public static class IntencaoVendaSpecification
    {
        public static Expression<Func<IntencaoVenda, bool>> IntencoesVendaAguardandoRevisao()
        {
            return x => x.Status == Enuns.EStatusIntencaoVenda.AguardandoRevisao;
        }
    }
}
