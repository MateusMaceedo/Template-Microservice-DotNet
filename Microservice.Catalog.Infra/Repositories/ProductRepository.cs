using Microservice.Catalog.Domain.Entities.Base;
using Microservice.Catalog.Infra.Repositories.Base;

namespace Microservice.Catalog.Infra.Repositories
{
    public class ProductRepository : RepositoryBase<Entity>, IProductRepository
    {
        public ProductRepository(DbConnectionString settings)
        : base("Product", settings)
        { }
    }
}
