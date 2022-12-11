using Microservice.Catalog.Domain.Entities;
using MongoDB.Driver;

namespace Microservice.Catalog.Infra.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<ProductEntity> Products { get; }
    }
}
