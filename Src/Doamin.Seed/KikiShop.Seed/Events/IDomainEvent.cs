using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiShop.Seed.Events
{
    public interface IDomainEvent : INotification
    {
        DateTime CreatedAt { get; }
    }
}
