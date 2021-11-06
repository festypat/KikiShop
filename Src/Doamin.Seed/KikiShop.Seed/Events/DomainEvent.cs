using System;

namespace KikiShop.Seed.Events
{
    public abstract class DomainEvent : Message, IDomainEvent
    {
        public DateTime CreatedAt { get; private set; }

        public DomainEvent()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
