using Admin.Picareta.Domain.Queries.Specifications;
using Admin.Picareta.Entidades;
using Admin.Picareta.Interfaces.Repositories;
using Admin.Picareta.ValueObjects;
using Core.Picareta.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Admin.Picareta.Data.Repositories
{
    public class IntencaoVendaRepository : RepositoryBase, IIntencaoVendaRepository
    {
        public void AddIntencaoVenda(IntencaoVenda intencaoVenda)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IntencaoVenda> GetIntencoesVendasPendentesAvaliacao()
        {
            //listagem mockada só pra testar o bagulho
            //após implementar o post dessa entidade, já da pra trocar
            var listaDb = new List<IntencaoVenda>();
            for (int i = 0; i < 15; i++)
            {
                var modelo = new Modelo("Gol", 10000, 20000);
                var carro = new Carro("Branco", GerarPreco(), modelo);
                listaDb.Add(new IntencaoVenda(carro, modelo));
            }

            return listaDb.AsQueryable().Where(IntencaoVendaSpecification.IntencoesVendaAguardandoRevisao());
        }

        //TODO: remover
        public int GerarPreco()
        {
            Random r = new Random();
            int rInt = r.Next(0, 20000); 
            return rInt;
        }
    }
}
