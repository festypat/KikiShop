using MediatR;
using System;

namespace KikiShop.Seed.Events
{
    public interface IDomainEvent : INotification
    {
        DateTime CreatedAt { get; }
    }
}
