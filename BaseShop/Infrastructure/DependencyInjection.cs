using System;
using Application.Abstractions.Serilog;
using Application.Caching;
using Infrastructure.Caching;
using Infrastructure.CustomeLogger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Asp.Versioning;
using Domain.Abstractions;
using Domain.Shop.Auth;
using Domain.Shop;
using Infrastructure.Data.Repositories;
using static Infrastructure.Data.Repositories.OrderItemRepository;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            AddPersistence(services, configuration);

            AddCaching(services, configuration);

            AddHealthChecks(services, configuration);

            AddApiVersioning(services);

            return services;
        }
        private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString =
                        configuration.GetConnectionString("Database") ??
                        throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<OnlineStoreContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Houshmand.Peyman.Infrastructure")).UseSnakeCaseNamingConvention());



         

            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<OrderItem>, OrderItemRepository>();
            services.AddScoped<IRepository<Cart>, CartRepository>();
            services.AddScoped<IRepository<CartItem>, CartItemRepository>();

            //services.AddMediator(typeof(Startup).Assembly);

            services.AddSingleton<ISerilogService, SerilogService>();
            

        }

        private static void AddCaching(IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Cache") ??
                                       throw new ArgumentNullException(nameof(configuration));

            services.AddStackExchangeRedisCache(options => options.Configuration = connectionString);

            services.AddSingleton<ICacheService, CacheService>();
        }

        private static void AddHealthChecks(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                //.addsq(configuration.GetConnectionString("Database")!) //TODO Adding Health Check For 
                //Sql sever 
                .AddRedis(configuration.GetConnectionString("Cache")!)
                .AddUrlGroup(new Uri(configuration["KeyCloack:BaseUrl"]!), HttpMethod.Get, "keycloack");
        }

        private static void AddApiVersioning(IServiceCollection services)
        {
            services
                .AddApiVersioning(options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1);
                    options.ReportApiVersions = true;
                    options.ApiVersionReader = new UrlSegmentApiVersionReader();
                })
                .AddMvc()
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'V";
                    options.SubstituteApiVersionInUrl = true;
                });
        }
    }
}

