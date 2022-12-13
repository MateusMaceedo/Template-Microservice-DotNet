using Microservice.Catalog.Domain.Interfaces.Cache;
using Microservice.Catalog.Infra.Repositories.Cache;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Catalog.Infra.Extensions
{
    public static class CacheExtensions
    {
        public static void RegistrarCache(this IServiceCollection services)
        {
            services.AddStackExchangeRedisCache(o => {
                o.InstanceName = "instance";
                o.Configuration = "localhost:6379";
            });

            services.AddScoped<ICache, Cache>();
        }
    }
}
