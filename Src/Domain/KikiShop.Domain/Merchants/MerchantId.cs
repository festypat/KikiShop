using KikiShop.Seed;
using System;

namespace KikiShop.Domain.Merchants
{

    public class MerchantId : StronglyTypedId<MerchantId>
    {
        public MerchantId(Guid value) : base(value)
        {
        }

        public static MerchantId Of(Guid merchantId)
        {
            if (merchantId == Guid.Empty)
                throw new BusinessRuleException("Customer Id must be provided.");

            return new MerchantId(merchantId);
        }
    }
}
