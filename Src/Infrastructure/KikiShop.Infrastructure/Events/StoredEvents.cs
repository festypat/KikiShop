using KikiShop.Infrastructure.KikiShop.Database.Context;
using KikiShop.Seed.Events;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KikiShop.Infrastructure.Events
{
    public class StoredEvents : IStoredEvents
    {
        private readonly KikiShopDbContext _dbContext;

        public StoredEvents(KikiShopDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void UpdateProcessedAt(StoredEvent message)
        {
            _dbContext.StoredEvents.Update(message);
        }

        public async Task StoreRange(List<StoredEvent> messages)
        {
            await _dbContext.StoredEvents.AddRangeAsync(messages);
        }

        public async Task<IList<StoredEvent>> GetByAggregateId(Guid aggregateId, CancellationToken cancellationToken)
        {
            var results = await _dbContext.StoredEvents
                .Where(c => c.AggregateId == aggregateId)
                .OrderBy(m => m.CreatedAt)
                .ToListAsync(cancellationToken);

            return results;
        }

        public async Task<IReadOnlyCollection<StoredEvent>> FetchUnprocessed(int batchSize, CancellationToken cancellationToken)
        {
            var results = await _dbContext.StoredEvents
                .Where(m => null == m.ProcessedAt)
                .OrderBy(m => m.CreatedAt)
                .Take(batchSize)
                .ToArrayAsync(cancellationToken);

            return results.ToImmutableArray();
        }
    }

}
