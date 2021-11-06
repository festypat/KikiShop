using KikiShop.Domain.Merchants;
using KikiShop.Seed.Events;
using Microsoft.EntityFrameworkCore;

namespace KikiShop.Infrastructure.KikiShop.Database.Context
{

    public sealed class KikiShopDbContext : DbContext
    {
        public DbSet<Merchant> Merchants { get; set; }     
        public DbSet<StoredEvent> StoredEvents { get; set; }
        public KikiShopDbContext(DbContextOptions<KikiShopDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KikiShopDbContext).Assembly);
        }
    }

}
