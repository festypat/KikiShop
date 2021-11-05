using KikiShop.Domain.Merchants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiShop.ApplicationCore.Merchants
{
    public class MerchantUniquenessChecker : IMerchantUniquenessChecker
    {
        private readonly IKikiShopUnitOfWork _unitOfWork;

        public MerchantUniquenessChecker(IKikiShopUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool IsUserUnique(string customerEmail)
        {
            var customer = _unitOfWork.Merchants
                .GetByEmail(customerEmail).Result;

            return customer == null;
        }
    }

}
