using KikiShop.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
