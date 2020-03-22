using Admin.Picareta.Entidades;
using Admin.Picareta.Enuns;
using Admin.Picareta.ValueObjects;
using System;
using System.ComponentModel;
using Xunit;

namespace Admin.Picareta.Tests
{
    public class IntencaoVendaTests
    {
        [Trait("Entidade","IntencaoVenda")]
        [Fact]
        public void ValorAbaixoDoMinimo_DeveEnviarParaAnaliseManual()
        {
            //Arrange
            var modelo = new Modelo("Marea", 8000, 12000);
            var carro = new Carro(Guid.NewGuid(), "Azul", 7000, modelo);


            //Act
            var intencaoVenda = new IntencaoVenda(carro);

            //Assert
            Assert.Equal(EStatusIntencaoVenda.AguardandoRevisao, intencaoVenda.Status);
            Assert.Equal(EModoAprovacao.Manual, intencaoVenda.ModoAprovacao);
        }

        [Trait("Entidade", "IntencaoVenda")]
        [Fact]
        public void ValorMaiorDoMAximo_DeveEnviarParaAnaliseManual()
        {
            //Arrange
            var modelo = new Modelo("Marea", 8000, 12000);
            var carro = new Carro(Guid.NewGuid(), "Azul", 13000, modelo);


            //Act
            var intencaoVenda = new IntencaoVenda(carro);

            //Assert
            Assert.Equal(EStatusIntencaoVenda.AguardandoRevisao, intencaoVenda.Status);
            Assert.Equal(EModoAprovacao.Manual, intencaoVenda.ModoAprovacao);
        }

        [Trait("Entidade", "IntencaoVenda")]
        [Fact]
        public void ValorEntreOsLimitesMinimoEMaximo_DeveAprovarAutomaticamente()
        {
            //Arrange
            var modelo = new Modelo("Marea", 8000, 12000);
            var carro = new Carro(Guid.NewGuid(), "Azul", 11000, modelo);


            //Act
            var intencaoVenda = new IntencaoVenda(carro);

            //Assert
            Assert.Equal(EStatusIntencaoVenda.Aprovado, intencaoVenda.Status);
            Assert.Equal(EModoAprovacao.Automatico, intencaoVenda.ModoAprovacao);
        }

        [Trait("Entidade", "IntencaoVenda")]
        [Fact]
        public void RegistrarReprovacao_DeveRetornarStatusReprovado()
        {

            //Arrange
            var modelo = new Modelo("Marea", 8000, 12000);
            var carro = new Carro(Guid.NewGuid(), "Azul", 13000, modelo);


            //Act
            var intencaoVenda = new IntencaoVenda(carro);
            intencaoVenda.RegistarReprovacao();

            //Assert
            Assert.Equal(EModoAprovacao.Manual, intencaoVenda.ModoAprovacao);
            Assert.Equal(EStatusIntencaoVenda.Reprovado, intencaoVenda.Status);
            
        }

        [Trait("Entidade", "IntencaoVenda")]
        [Fact]
        public void RegistrarAprovacao_DeveRetornarStatusAprovado()
        {
            //Arrange
            var modelo = new Modelo("Marea", 8000, 12000);
            var carro = new Carro(Guid.NewGuid(), "Azul", 13000, modelo);


            //Act
            var intencaoVenda = new IntencaoVenda(carro);
            intencaoVenda.RegistarAprovacaoManual();

            //Assert
            Assert.Equal(EModoAprovacao.Manual, intencaoVenda.ModoAprovacao);
            Assert.Equal(EStatusIntencaoVenda.Aprovado, intencaoVenda.Status);

        }
    }
}
