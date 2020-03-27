using Admin.Picareta.Entidades;
using Admin.Picareta.Entidades.Validators;
using Core.Picareta.DomainObjects;
using System;

namespace Admin.Picareta.ValueObjects
{
    public class Carro : ValueObject
    {
        public Carro(string cor, decimal valor, Modelo modelo)
        {
            Cor = cor;
            Modelo = modelo;
            Valor = valor;

            ValidationResult = new CarroValidator().Validate(this);
        }

        public string Cor { get; private set; }
        public decimal Valor { get; private set; }
        public Modelo Modelo { get; private set; }
    }
}
