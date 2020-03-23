using Admin.Picareta.Entidades.Validators;
using Core.picareta.DomainObjects;
using Core.Picareta.DomainObjects;

namespace Admin.Picareta.Entidades
{
    public class Modelo : Entity, IAggregateRoot
    {
        public Modelo(string nome, decimal valorMinimo, decimal valorMaximo)
        {
            Nome = nome;
            ValorMinimo = valorMinimo;
            ValorMaximo = valorMaximo;

            //Validation = new ModeloValidator().Validate(this);
        }

        public string Nome { get; private set; }
        public decimal ValorMinimo { get; private set; }
        public decimal ValorMaximo { get; private set; }

    }
}
