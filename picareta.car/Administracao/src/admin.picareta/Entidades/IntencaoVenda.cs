using Admin.Picareta.Enuns;
using Admin.Picareta.ValueObjects;
using Core.picareta.DomainObjects;
using Core.Picareta.DomainObjects;
using System;

namespace Admin.Picareta.Entidades
{
    public class IntencaoVenda : Entity, IAggregateRoot
    {
        public IntencaoVenda(Carro carro)
        {
            Status = EStatusIntencaoVenda.AguardandoAvaliacao;
            Revisar(carro);
        }
        public EStatusIntencaoVenda Status { get; private set; }
        public EModoAprovacao ModoAprovacao { get; private set; }
        public DateTime DataRevisao { get; private set; }
        public Carro Carro { get; private set; }

        public void Revisar(Carro carro)
        {
            if (carro.Valor <= carro.Modelo.ValorMaximo || carro.Valor >= carro.Modelo.ValorMinimo)
            {
                RegistrarAprovacaoAutomatica();
            }
            else
            {
                EnviarParaAprovacaoManual();
            }
        }

       

        private void RegistrarAprovacaoAutomatica()
        {
            ModoAprovacao = EModoAprovacao.Automatico;
            Aprovar();
        }

        public void RegistarReprovacao()
        {
            Status = EStatusIntencaoVenda.Reprovado;
        }

        public void RegistarAprovacaoManual()
        {
            ModoAprovacao = EModoAprovacao.Manual;
            Aprovar();
        }

        #region Private Methods

        private void Aprovar()
        {
            Status = EStatusIntencaoVenda.Aprovado;
            DataRevisao = DateTime.Now;
        }

        private void EnviarParaAprovacaoManual()
        {
            ModoAprovacao = EModoAprovacao.Manual;
        }

        #endregion
    }

   
}
