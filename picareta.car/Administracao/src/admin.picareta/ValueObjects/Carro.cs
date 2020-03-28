using Admin.Picareta.Entidades;
using Admin.Picareta.Entidades.Validators;
using Core.Picareta.DomainObjects;
using FluentValidation.Results;
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
        }

        public string Cor { get; private set; }
        public decimal Valor { get; private set; }
        public Modelo Modelo { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new CarroValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
