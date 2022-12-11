using Microservice.Catalog.Domain.Entities;
using Microservice.Catalog.Infra.Data;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Microservice.Catalog.Infra.Context
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString
                ("DatabaseSettings:ConnectionString"));

            var database = client.GetDatabase(configuration.GetConnectionString
                ("DatabaseSettings:Database"));

            Products = database.GetCollection<ProductEntity>(configuration.GetConnectionString
                ("DatabaseSettings:CollectionName"));

            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<ProductEntity> Products { get; }
    }
}
