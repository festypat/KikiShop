using KikiShop.Seed.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiShop.Domain.Merchants.Events
{
    public class MerchantRegisteredEvent : DomainEvent
    {
        public MerchantId MerchantId { get; private set; }
        public string Name { get; private set; }

        public MerchantRegisteredEvent(MerchantId merchantId, string name)
        {
            MerchantId = merchantId;
            Name = name;
            AggregateId = merchantId.Value;
        }
    }
}
