using Admin.Picareta.Entidades;
using Admin.Picareta.ValueObjects;
using Xunit;

namespace Admin.Picareta.Tests.ValueObjects
{
    public class CarroTests
    {
        [Trait("ValueObjects", "Carro")]
        [Fact]
        public void CarroInvalido_DeveRetornarFalse()
        {
            //Arrange
            var modelo = new Modelo("Gol", 1200, 1900);
            var carro = new Carro("", 0, modelo);

            //Act
            var result = carro.IsValid();

            //Assert
            Assert.False(result);

        }
    }
}
