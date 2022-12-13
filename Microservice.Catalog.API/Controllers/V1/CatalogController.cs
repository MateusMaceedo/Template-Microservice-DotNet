using Microservice.Catalog.API.Contracts;
using Microservice.Catalog.Domain.Entities;
using Microservice.Catalog.Domain.Interfaces.Cache;
using Microservice.Catalog.Infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.Catalog.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase, ICatalogContracts
    {
        private readonly IProductRepository _repository;
        private readonly ICache _cache;

        public CatalogController(IProductRepository repository, ICache cache)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _cache = cache;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductEntity>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable>> GetProducts()
        {
            var products = await _repository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProductEntity), StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductEntity>> GetProductById(string id)
        {
            var productCache = await _cache.GetAsync(id.ToString());
            ProductEntity productEntity = null;

            if (!(string.IsNullOrWhiteSpace(productCache)))
            {
                productEntity = await _repository.GetProduct(id);
                Console.WriteLine("Loadded from cache.");

                return Ok(productEntity);
            }

            if (productEntity is null)
                return NotFound();

            await _cache.SetAsync(id.ToString(), productEntity.ToString());

            return Ok(productEntity);
        }

        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductEntity>))]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> 
            GetProductByCategory(string category)
        {
            if (category == null)
                return BadRequest("Invalid category");

            var product = await _repository.GetProductByCategory(category);

            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductEntity>> 
            CreateProduct([FromBody] ProductEntity product)
        {
            if (product is null)
                return BadRequest("Invalid product");

            await _repository.CreateProduct(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductEntity product)
        {
            if (product is null)
                return BadRequest("Invalid product");

            return Ok(await _repository.UpdateProduct(product));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(ProductEntity), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _repository.DeleteProduct(id));
        }
    }
}
