using System;

namespace Core.picareta.DomainObjects
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        //public ValidationResult Validation { get; set; }
        
    }
}
