using Admin.Picareta.Entidades;
using Admin.Picareta.Enuns;
using Admin.Picareta.ValueObjects;
using Xunit;

namespace Admin.Picareta.Tests
{
    public class IntencaoVendaTests
    {

        [Trait("Entidade", "IntencaoVenda")]
        [Fact]
        public void ValorAbaixoDoMinimo_DeveEnviarParaAnaliseManual()
        {
            //Arrange
            var modelo = new Modelo("Marea", 8000, 12000);
            var carro = new Carro("Azul", 7000, modelo);


            //Act
            var intencaoVenda = new IntencaoVenda(carro, modelo);

            //Assert
            Assert.Null(intencaoVenda.DataRevisao);
            Assert.False(intencaoVenda.Revisado);
            Assert.Equal(EStatusIntencaoVenda.AguardandoRevisao, intencaoVenda.Status);
            Assert.Equal(EModoAprovacao.Manual, intencaoVenda.ModoAprovacao);
        }

        [Trait("Entidade", "IntencaoVenda")]
        [Fact]
        public void ValorMaiorDoMaximo_DeveEnviarParaAnaliseManual()
        {
            //Arrange
            var modelo = new Modelo("Marea", 8000, 12000);
            var carro = new Carro("Azul", 13000, modelo);


            //Act
            var intencaoVenda = new IntencaoVenda(carro, modelo);

            //Assert
            Assert.Null(intencaoVenda.DataRevisao);
            Assert.False(intencaoVenda.Revisado);
            Assert.Equal(EStatusIntencaoVenda.AguardandoRevisao, intencaoVenda.Status);
            Assert.Equal(EModoAprovacao.Manual, intencaoVenda.ModoAprovacao);
        }

        [Trait("Entidade", "IntencaoVenda")]
        [Fact]
        public void ValorEntreOsLimitesMinimoEMaximo_DeveAprovarAutomaticamente()
        {
            //Arrange
            var modelo = new Modelo("Marea", 8000, 12000);
            var carro = new Carro("Azul", 11000, modelo);


            //Act
            var intencaoVenda = new IntencaoVenda(carro, modelo);

            //Assert
            Assert.NotNull(intencaoVenda.DataRevisao);
            Assert.True(intencaoVenda.Revisado);
            Assert.Equal(EStatusIntencaoVenda.Aprovado, intencaoVenda.Status);
            Assert.Equal(EModoAprovacao.Automatico, intencaoVenda.ModoAprovacao);
        }

        [Trait("Entidade", "IntencaoVenda")]
        [Fact]
        public void RegistrarReprovacao_DeveRetornarStatusReprovado()
        {

            //Arrange
            var modelo = new Modelo("Marea", 8000, 12000);
            var carro = new Carro("Azul", 13000, modelo);


            //Act
            var intencaoVenda = new IntencaoVenda(carro, modelo);
            intencaoVenda.RegistarReprovacao();

            //Assert
            Assert.NotNull(intencaoVenda.DataRevisao);
            Assert.True(intencaoVenda.Revisado);
            Assert.Equal(EModoAprovacao.Manual, intencaoVenda.ModoAprovacao);
            Assert.Equal(EStatusIntencaoVenda.Reprovado, intencaoVenda.Status);

        }

        [Trait("Entidade", "IntencaoVenda")]
        [Fact]
        public void RegistrarAprovacao_DeveRetornarStatusAprovado()
        {
            //Arrange
            var modelo = new Modelo("Marea", 8000, 12000);
            var carro = new Carro("Azul", 13000, modelo);



            //Act
            var intencaoVenda = new IntencaoVenda(carro, modelo);
            intencaoVenda.RegistarAprovacaoManual();

            //Assert
            Assert.NotNull(intencaoVenda.DataRevisao);
            Assert.True(intencaoVenda.Revisado);
            Assert.Equal(EModoAprovacao.Manual, intencaoVenda.ModoAprovacao);
            Assert.Equal(EStatusIntencaoVenda.Aprovado, intencaoVenda.Status);

        }
    }
}
