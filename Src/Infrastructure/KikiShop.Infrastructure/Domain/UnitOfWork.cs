using KikiShop.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KikiShop.Infrastructure.Domain
{
    public abstract class UnitOfWork<TDB> : IUnitOfWork
     where TDB : DbContext
    {
        protected readonly TDB DbContext;

        protected UnitOfWork(TDB dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
        {
            await StoreEvents(cancellationToken);
            return await DbContext.SaveChangesAsync(cancellationToken) > 0;
        }

        protected abstract Task StoreEvents(CancellationToken cancellationToken);
    }

}
