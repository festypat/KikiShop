namespace KikiShop.Domain.Merchants
{

    public interface IMerchantUniquenessChecker
    {
        bool IsUserUnique(string customerEmail);
    }
}
