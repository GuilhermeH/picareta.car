using Admin.Picareta.Commands;
using Admin.Picareta.Entidades.Events.IntegrationEvents;
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
        public IntencaoVenda(Carro carro, Modelo modelo)
        {
            Status = EStatusIntencaoVenda.AguardandoRevisao;
            Carro = carro;
            Revisar(carro, modelo);
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
            AdicionarEvento(new EnviarCarroParaVendasEvent(Carro.Modelo.Nome, Carro.Cor, Carro.Valor));
        }

        private void Revisar(Carro carro, Modelo modelo)
        {
            if (carro.Valor <= modelo.ValorMaximo && carro.Valor >= modelo.ValorMinimo)
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
