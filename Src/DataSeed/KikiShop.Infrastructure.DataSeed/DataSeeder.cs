using KikiShop.Domain.Merchants;
using KikiShop.Infrastructure.KikiShop.Database.Context;
using KikiShop.Infrastructure.KikiShop.Database.Domain;
using KikiShop.Infrastructure.KikiShop.Database.Domain.Merchants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace KikiShop.Infrastructure.DataSeed
{
    class DataSeeder
    {
        private static IServiceProvider _serviceProvider;

        static async Task Main(string[] args)
        {
            RegisterServices();

            var unitOfWork = _serviceProvider.GetService<IKikiShopUnitOfWork>();
            //await SeedProducts.SeedData(unitOfWork, currencyConverter);

            DisposeServices();
            Console.Read();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            var connString = GetDbConnection();
            services.AddDbContext<KikiShopDbContext>(options =>
            options.UseSqlServer(connString));

            services.AddScoped<IKikiShopUnitOfWork, KikiShopUnitOfWork>();
            services.AddScoped<IMerchants, Merchants>();           
            services.AddScoped<KikiShopDbContext>();

            _serviceProvider = services.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
                return;
            if (_serviceProvider is IDisposable)
                ((IDisposable)_serviceProvider).Dispose();
        }

        private static string GetDbConnection()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            string strConnection = builder.Build().GetConnectionString("DefaultConnection");

            return strConnection;
        }
    }

}
