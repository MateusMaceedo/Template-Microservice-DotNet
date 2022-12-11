using Microservice.Catalog.Domain.Entities;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Microservice.Catalog.Infra.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<ProductEntity> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetMyProducts());
            }
        }

        private static IEnumerable<ProductEntity> GetMyProducts()
        {
            return new List<ProductEntity>()
            {
                new ProductEntity()
                {
                    Id = "",
                    Name = "IPhone 8",
                    Description = "",
                    Image = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new ProductEntity()
                {
                    Id = "",
                    Name = "",
                    Description = "IPhone 11",
                    Image = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new ProductEntity()
                {
                    Id = "",
                    Name = "IPhone 13",
                    Description = "",
                    Image = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new ProductEntity()
                {
                    Id = "",
                    Name = "IPhone 14",
                    Description = "",
                    Image = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
            };
        }
    }
}
