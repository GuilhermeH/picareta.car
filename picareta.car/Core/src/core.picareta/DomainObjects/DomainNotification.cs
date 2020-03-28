using MediatR;
using System;

namespace Core.Picareta.DomainObjects
{
    public class DomainNotification : INotification
    {
        public DateTime Timestamp { get; private set; }
        public Guid Id { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        public DomainNotification(string key, string value)
        {
            Timestamp = DateTime.Now;
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
        }
    }
}
