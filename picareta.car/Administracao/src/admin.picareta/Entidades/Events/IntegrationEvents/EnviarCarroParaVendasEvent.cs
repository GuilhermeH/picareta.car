using Core.Picareta.DomainObjects;

namespace Admin.Picareta.Entidades.Events.IntegrationEvents
{
    public class EnviarCarroParaVendasEvent : IntegrationEvent
    {
        public EnviarCarroParaVendasEvent(string nomeModelo, string cor, decimal valor)
        {
            NomeModelo = nomeModelo;
            Cor = cor;
            Valor = valor;
        }

        public string NomeModelo { get; private set; }
        public string Cor { get; private set; }
        public decimal Valor { get; private set; }
    }
}
