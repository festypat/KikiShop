using KikiShop.ApplicationCore.AutoMapperSettings;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KikiShop.API.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(MappingProfiles));
        }
    }
}
