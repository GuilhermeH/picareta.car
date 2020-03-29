using Admin.Picareta.Entidades;
using Xunit;

namespace Admin.Picareta.Tests
{
    public class ModeloTests
    {
        [Trait("Entidade", "Modelo")]
        [Fact]
        public void ModeloInvalido_IsValid_DeveRetornarFalse()
        {
            //Arrange
            var modelo = new Modelo("Gol", 10000, 600);

            //Act    
            var result = modelo.IsValid();

            //Assert
            Assert.False(result);
        }

        [Trait("Entidade", "Modelo")]
        [Fact]
        public void ModeloValido_IsValid_DeveRetornarTrue()
        {
            //Arrange
            var modelo = new Modelo("Gol", 1000, 1600);

            //Act    
            var result = modelo.IsValid();

            //Assert
            Assert.True(result);
        }

    }
}
