using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Microservice.Catalog.Infra.Extensions
{
    public static class SwaggerExtensions
    {
        public static void RegistrarSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microservice.Catalog.API", Version = "v1" });
            });
        }
    }
}
