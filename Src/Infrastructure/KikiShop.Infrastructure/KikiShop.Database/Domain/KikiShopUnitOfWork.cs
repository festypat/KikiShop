using KikiShop.Domain.Merchants;
using KikiShop.Infrastructure.Domain;
using KikiShop.Infrastructure.Events;
using KikiShop.Infrastructure.KikiShop.Database.Context;
using KikiShop.Seed;
using KikiShop.Seed.Events;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KikiShop.Infrastructure.KikiShop.Database.Domain
{

    public class KikiShopUnitOfWork : UnitOfWork<KikiShopDbContext>, IKikiShopUnitOfWork
    {
        public IMerchants Merchants { get; }        
        public IStoredEvents StoredEvents { get; }       

        private readonly IEventSerializer _eventSerializer;

        public KikiShopUnitOfWork(KikiShopDbContext dbContext,
            IMerchants merchants,          
            IStoredEvents storedEvents,          
            IEventSerializer eventSerializer) : base(dbContext)
        {
            Merchants = merchants ?? throw new ArgumentNullException(nameof(merchants));
            StoredEvents = storedEvents ?? throw new ArgumentNullException(nameof(storedEvents));        

            _eventSerializer = eventSerializer ?? throw new ArgumentNullException(nameof(eventSerializer));
        }

        protected async override Task StoreEvents(CancellationToken cancellationToken)
        {
            var entities = DbContext.ChangeTracker.Entries()
                .Where(e => e.Entity is IAggregateRoot c && c.DomainEvents != null)
                .Select(e => e.Entity as IAggregateRoot)
                .ToArray();

            foreach (var entity in entities)
            {
                var messages = entity.DomainEvents
                    .Select(e => StoredEventHelper.BuildFromDomainEvent(e as DomainEvent, _eventSerializer))
                    .ToArray();

                entity.ClearDomainEvents();
                await DbContext.AddRangeAsync(messages, cancellationToken);
            }
        }
    }

}
