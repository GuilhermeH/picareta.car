using Admin.Picareta.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Admin.Picareta.Tests
{
    public class ModeloTests
    {
        //TODO: apagar teste depois
        [Trait("Modelo", "IntencaoVenda")]
        [Fact]
        public void NomeModelInvalidoTest()
        {
            //Arrange
            var nomeModelo = "Gol";

            //Act    
            var modelo = new Modelo(nomeModelo, 10000, 15000);

            //Assert
            Assert.True(true);
        }

    }
}
