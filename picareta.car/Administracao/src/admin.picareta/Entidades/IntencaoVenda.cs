using Admin.Picareta.Enuns;
using Admin.Picareta.ValueObjects;
using Core.picareta.DomainObjects;
using Core.Picareta.DomainObjects;
using FluentValidation;
using System;

namespace Admin.Picareta.Entidades
{
    public class IntencaoVenda : Entity, IAggregateRoot
    {
        public IntencaoVenda(Carro carro)
        {
            Status = EStatusIntencaoVenda.AguardandoRevisao;
            Revisar(carro);
        }
        public EStatusIntencaoVenda Status { get; private set; }
        public EModoAprovacao ModoAprovacao { get; private set; }
        public DateTime? DataRevisao { get; private set; }
        public bool Revisado { get; set; }
        public Carro Carro { get; private set; }
       
        public void RegistarReprovacao()
        {
            Reprovar();
        }

        public void RegistarAprovacaoManual()
        {
            ModoAprovacao = EModoAprovacao.Manual;
            Aprovar();
        }

        #region Private Methods

        private void RegistrarAprovacaoAutomatica()
        {
            ModoAprovacao = EModoAprovacao.Automatico;
            Aprovar();
        }

        private void Revisar(Carro carro)
        {
            if (carro.Valor <= carro.Modelo.ValorMaximo && carro.Valor >= carro.Modelo.ValorMinimo)
            {
                RegistrarAprovacaoAutomatica();
            }
            else
            {
                EnviarParaAprovacaoManual();
            }
        }

        private void Aprovar()
        {
            Revisado = true;
            Status = EStatusIntencaoVenda.Aprovado;
            DataRevisao = DateTime.Now;
        }

        private void Reprovar()
        {
            Revisado = true;
            Status = EStatusIntencaoVenda.Reprovado;
            DataRevisao = DateTime.Now;
        }

        private void EnviarParaAprovacaoManual()
        {
            Revisado = false;
            ModoAprovacao = EModoAprovacao.Manual;
        }

        #endregion
    }

   
}
