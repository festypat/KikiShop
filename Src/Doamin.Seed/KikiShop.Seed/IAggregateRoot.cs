using KikiShop.Seed.Events;
using System.Collections.Generic;

namespace KikiShop.Seed
{
    public interface IAggregateRoot
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
        void ClearDomainEvents();
    }
}
