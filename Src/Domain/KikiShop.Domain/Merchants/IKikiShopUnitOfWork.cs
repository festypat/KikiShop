using KikiShop.Seed;
using KikiShop.Seed.Events;

namespace KikiShop.Domain.Merchants
{

    public interface IKikiShopUnitOfWork : IUnitOfWork
    {
        IMerchants Merchants { get; }
        //IOrders Orders { get; }
        //IProducts Products { get; }
        //IQuotes Quotes { get; }
        //IPayments Payments { get; }
        IStoredEvents StoredEvents { get; }
    }
}
