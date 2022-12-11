using Microservice.Catalog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.Catalog.API.Contracts
{
    public interface ICatalogContracts
    {
        Task<ActionResult<IEnumerable>> GetProducts();
        Task<ActionResult<ProductEntity>> GetProductById(string id);
        Task<ActionResult<IEnumerable<ProductEntity>>> GetProductByCategory(string category);
        Task<ActionResult<ProductEntity>> CreateProduct([FromBody] ProductEntity product);
        Task<ActionResult> UpdateProduct([FromBody] ProductEntity product);
        Task<IActionResult> DeleteProductById(string id);
    }
}
