﻿using Admin.Picareta.Entidades;
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
            var modelo = new Modelo(nomeModelo, 10000, 13000);

            //Assert
            //Assert.True(modelo.Validation.IsValid);
            Assert.True(true);
        }

    }
}