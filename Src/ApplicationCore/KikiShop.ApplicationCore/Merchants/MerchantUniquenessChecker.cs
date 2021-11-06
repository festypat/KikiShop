using KikiShop.Domain.Merchants;

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
