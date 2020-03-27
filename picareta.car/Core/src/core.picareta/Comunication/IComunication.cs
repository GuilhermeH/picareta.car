using Core.Picareta.DomainObjects;
using System.Threading.Tasks;

namespace Core.Picareta.Comunication
{
    public interface IComunication
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
    }
}
