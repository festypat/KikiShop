using KikiShop.Domain.Merchants.Events;
using KikiShop.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiShop.Domain.Merchants
{
    public class Merchant : AggregateRoot<MerchantId>
    {
        public string Email { get; private set; }
        public string Name { get; private set; }

        public static Merchant CreateNew(string email, string name,
            IMerchantUniquenessChecker customerUniquenessChecker)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Customer name cannot be null or whitespace.", nameof(name));

            if (!customerUniquenessChecker.IsUserUnique(email))
                throw new BusinessRuleException("This e-mail is already in use.");

            return new Merchant(MerchantId.Of(Guid.NewGuid()), email, name);
        }

        public void SetName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));

            Name = value;
            AddDomainEvent(new MerchantUpdatedEvent(Id, Name));
        }

        private Merchant(MerchantId id, string email, string name)
        {
            Id = id;
            Email = email;
            Name = name;
            AddDomainEvent(new MerchantRegisteredEvent(Id, Name));
        }

        // Empty constructor for EF
        private Merchant() { }
    }

}
