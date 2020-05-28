using Admin.Picareta.Data.Context;
using Admin.Picareta.Domain.Interfaces.Repositories;
using Admin.Picareta.Entidades;
using Core.Picareta.Data;
using MongoDB.Driver;
using System;

namespace Admin.Picareta.Data.Repositories
{
    public class ModeloRepository : RepositoryBase, IModeloRepository
    {
        private readonly AdminMongoContext _mongoContext;

        public ModeloRepository(AdminMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }
        public void AddModelo(Modelo modelo)
        {
            _mongoContext.GetModeloCollection().InsertOne(modelo);
        }

        public Modelo GetModelo(Guid modeloId)
        {
            throw new NotImplementedException();
        }
    }
}
