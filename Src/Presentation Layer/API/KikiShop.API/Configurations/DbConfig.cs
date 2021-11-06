using KikiShop.Infrastructure.KikiShop.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KikiShop.API.Configurations
{
    public static class DbConfig
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            string connString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<KikiShopDbContext>(options =>
            {
                options.UseSqlServer(connString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });
            });

            services.AddDbContextPool<IdentityContext>(options =>
            {
                options.UseSqlServer(connString);
            });
        }

    }
}
