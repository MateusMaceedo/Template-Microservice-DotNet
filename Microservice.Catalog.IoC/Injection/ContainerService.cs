using Microservice.Catalog.Core.UseCases;
using Microservice.Catalog.Domain.Interfaces.UseCases;
using Microservice.Catalog.Infra.Context;
using Microservice.Catalog.Infra.Data;
using Microservice.Catalog.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Catalog.IoC.Injection
{
    public static class ContainerService
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Contex
            services.AddScoped<ICatalogContext, CatalogContext>();

            // Repository
            services.AddScoped<IProductRepository, ProductRepository>();

            // UseCases
            services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
            services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();
            services.AddScoped<IGetProductByCategoryUseCase, GetProductByCategoryUseCase>();
            services.AddScoped<IGetProductByNameUseCase, GetProductByNameUseCase>();
            services.AddScoped<IGetProductsUseCase, GetProductsUseCase>();
            services.AddScoped<IGetProductUseCase, GetProductUseCase>();
            services.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();
        }
    }
}
