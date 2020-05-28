using Admin.Picareta.Entidades;
using Core.Picareta.DomainObjects;
using System;

namespace Admin.Picareta.Domain.Interfaces.Repositories
{
    public interface IModeloRepository : IRepository<Modelo>
    {
        void AddModelo(Modelo modelo);
        Modelo GetModelo(Guid modeloId);
    }
}
