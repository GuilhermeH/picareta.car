using Core.Picareta.DomainObjects;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Core.picareta.DomainObjects
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }

        private List<Event> _events;
        public IReadOnlyCollection<Event> Eventos => _events?.AsReadOnly();

        public void AdicionarEvento(Event evento)
        {
            _events = _events ?? new List<Event>();
            _events.Add(evento);
        }

        public void RemoverEvento(Event eventItem)
        {
            _events?.Remove(eventItem);
        }

        public void LimparEventos()
        {
            _events?.Clear();
        }

        public virtual bool IsValid()
        {
            return ValidationResult.IsValid;
        }

        public ValidationResult ValidationResult { get; set; }

    }
}
