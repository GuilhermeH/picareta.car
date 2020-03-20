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
                AprovarAutomaticamente();
            }
        }

        public void Aprovar()
        {
            Status = EStatusIntencaoVenda.Aprovado;
            DataRevisao = DateTime.Now;
        }

        public void AprovarAutomaticamente()
        {
            ModoAprovacao = EModoAprovacao.Automatico;
            Aprovar();
        }

        public void AprovarManualmente()
        {
            ModoAprovacao = EModoAprovacao.Manual;
            Aprovar();
        }

        public void Reprovar()
        {
            Status = EStatusIntencaoVenda.Reprovado;
        }
    }

   
}
