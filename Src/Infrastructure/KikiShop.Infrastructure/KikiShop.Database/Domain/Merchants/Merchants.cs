using KikiShop.Domain.Merchants;
using KikiShop.Infrastructure.KikiShop.Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KikiShop.Infrastructure.KikiShop.Database.Domain.Merchants
{

    public class Merchants : IMerchants
    {
        private readonly KikiShopDbContext _context;

        public Merchants(KikiShopDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Merchant merchant, CancellationToken cancellationToken = default)
        {
            await _context.Merchants.AddAsync(merchant, cancellationToken);
        }

        public async Task<Merchant> GetById(MerchantId id, CancellationToken cancellationToken = default)
        {
            return await _context.Merchants
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Merchant> GetByEmail(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Merchants
                .Where(c => c.Email == email)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }

}
