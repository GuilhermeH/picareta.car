namespace Core.Picareta.DomainObjects
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        /// <summary>
        /// Finalizacao lógica de uma transação dentro de um comando, deverá ser usada para 
        /// lançamento de eventos de integração
        /// </summary>
        void Commit();
    }
}
