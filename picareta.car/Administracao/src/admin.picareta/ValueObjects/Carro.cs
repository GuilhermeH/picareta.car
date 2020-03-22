using Admin.Picareta.Entidades;
using Core.Picareta.DomainObjects;
using System;

namespace Admin.Picareta.ValueObjects
{
    public class Carro : ValueObject
    {
        public Carro(Guid carroId, string cor, decimal valor, Modelo modelo)
        {
            CarroId = carroId;
            Cor = cor;
            Modelo = modelo;
            Valor = valor;
        }
        public Guid CarroId { get; private set; }
        public string Cor { get; private set; }
        public decimal Valor { get; private set; }
        public Modelo Modelo { get; private set; }
    }
}
