using KikiShop.ApplicationCore.Merchants;
using KikiShop.ApplicationCore.Merchants.Handlers;
using KikiShop.Domain.Merchants;
using KikiShop.Infrastructure.Events;
using KikiShop.Infrastructure.KikiShop.Database.Domain;
using KikiShop.Infrastructure.KikiShop.Database.Domain.Merchants;
using KikiShop.Seed.Events;
//using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using KikiShop.Infrastructure.KikiShop.Database.UserIdentity.Claims;
using KikiShop.Infrastructure.KikiShop.Database.UserIdentity.User;
using KikiShop.Infrastructure.KikiShop.Database.UserIdentity.Jwt;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using KikiShop.ApplicationCore.AutoMapperSettings;
using KikiShop.Infrastructure.Publisher;
using KikiShop.Infrastructure.Processor;
using KikiShop.ApplicationCore.Merchants.Command;

namespace KikiShop.Infrastructure.Ioc.Dependencies
{

    public static class ApplicationServiceExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Domain services
            services.AddScoped<IMerchantUniquenessChecker, MerchantUniquenessChecker>();

            // Application - Handlers            
            services.AddMediatR(typeof(RegisterMerchantCommandHandler).GetTypeInfo().Assembly);

            // Infra - Domain persistence
            services.AddScoped<IKikiShopUnitOfWork, KikiShopUnitOfWork>();
            services.AddScoped<IMerchants, Merchants>();

            services.AddAutoMapper(typeof(MappingProfiles));

            //services.AddSingleton<IRequestHandler<RegisterMerchantCommand, Guid>, RegisterMerchantCommandHandler>();

            // Infrastructure - Data EventSourcing
            services.AddScoped<IStoredEvents, StoredEvents>();
            services.AddSingleton<IEventSerializer, EventSerializer>();
            services.AddScoped<RegisterMerchantCommand>();
            // Infrastructure - Identity     
            services.AddTransient<IAuthorizationHandler, ClaimsRequirementHandler>();
            services.AddTransient<IApplicationUserDbAccessor, ApplicationUserDbAccessor>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IApplicationUser, ApplicationUser>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Messaging
            services.AddScoped<IMessagePublisher, MessagePublisher>();
            services.AddScoped<IMessageProcessor, MessageProcessor>();
        }
    }

}
