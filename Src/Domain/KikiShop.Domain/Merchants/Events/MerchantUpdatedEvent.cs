using KikiShop.Seed.Events;

namespace KikiShop.Domain.Merchants.Events
{
    public class MerchantUpdatedEvent : DomainEvent
    {
        public MerchantId MerchantId { get; private set; }
        public string Name { get; private set; }

        public MerchantUpdatedEvent(MerchantId merchantId, string name)
        {
            MerchantId = merchantId;
            Name = name;
            AggregateId = MerchantId.Value;
        }
    }
}
