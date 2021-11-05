using KikiShop.Domain.Merchants.Events;
using KikiShop.Seed.Events;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KikiShop.Infrastructure.Events
{
    public static class StoredEventHelper
    {
        public static StoredEvent BuildFromDomainEvent<TE>(TE @event, IEventSerializer serializer)
            where TE : DomainEvent
        {
            if (null == @event)
                throw new ArgumentNullException(nameof(@event));

            if (null == serializer)
                throw new ArgumentNullException(nameof(serializer));

            var type = @event.GetType().FullName;
            return new StoredEvent(@event, serializer.Serialize(@event));
        }

        public static T Deserialize<T>(StoredEvent message) where T : class, INotification
        {
            var type = GetEventType(message.MessageType);
            return JsonConvert.DeserializeObject(message.Payload, type) as T;
        }

        public static Type GetEventType(string messageType)
        {
            Type type = Assembly.GetAssembly(typeof(MerchantRegisteredEvent)).GetType(messageType);
            return type;
        }
    }

}
