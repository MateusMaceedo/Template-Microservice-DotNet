using Microservice.Catalog.Domain.Entities.Base;
using Microservice.Catalog.Domain.Interfaces.Repository;

namespace Microservice.Catalog.Infra.Repositories
{
    public interface IProductRepository : IRepositoryBase<Entity>
    { }
}
