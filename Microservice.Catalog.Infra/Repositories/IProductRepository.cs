using Microservice.Catalog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.Catalog.Infra.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetProducts();
        Task<ProductEntity> GetProduct(string id);
        Task<IEnumerable<ProductEntity>> GetProductByName(string name);
        Task<IEnumerable<ProductEntity>> GetProductByCategory(string categoryName);
        Task CreateProduct(ProductEntity product);
        Task<bool> UpdateProduct(ProductEntity product);
        Task<bool> DeleteProduct(string id);
    }
}
