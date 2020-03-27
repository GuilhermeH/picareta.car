using MediatR;
using System;

namespace Core.Picareta.DomainObjects
{
    public class Event : INotification
    {
        public Event()
        {
            DateTime = DateTime.Now;
        }
        public DateTime DateTime { get; set; }
    }
}
