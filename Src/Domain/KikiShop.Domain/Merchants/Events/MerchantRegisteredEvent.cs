using KikiShop.Seed.Events;

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
