using KikiShop.Infrastructure.KikiShop.Database.UserIdentity;
using KikiShop.Infrastructure.KikiShop.Database.UserIdentity.AppRoles;
using KikiShop.Infrastructure.KikiShop.Database.UserIdentity.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiShop.Infrastructure.KikiShop.Database.Context
{
    public class IdentityContext : IdentityDbContext<ApplicationUser, UserRole, Guid>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.Property(u => u.Id)
                    .HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<UserRole>(b =>
            {
                b.Property(u => u.Id)
                    .HasDefaultValueSql("newsequentialid()");
            });

            base.OnModelCreating(modelBuilder);
        }
    }

}
