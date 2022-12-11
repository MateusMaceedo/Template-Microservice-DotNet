using Microservice.Catalog.Domain.Entities;
using MongoDB.Driver;
using System;
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
            var id = Guid.NewGuid().ToString();

            return new List<ProductEntity>()
            {
                new ProductEntity()
                {
                    Id = id,
                    Name = "IPhone 6",
                    Description = "IPhone 8, lançamento em 2008",
                    Image = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new ProductEntity()
                {
                    Id = id,
                    Name = "IPhone 8",
                    Description = "IPhone 8, lançamento em 2009",
                    Image = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new ProductEntity()
                {
                    Id = id,
                    Name = "IPhone 11",
                    Description = "IPhone 11, lançamento em 2010",
                    Image = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new ProductEntity()
                {
                    Id = id,
                    Name = "IPhone 13",
                    Description = "IPhone 13, lançamento em 2020",
                    Image = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new ProductEntity()
                {
                    Id = id,
                    Name = "IPhone 14",
                    Description = "IPhone 14, lançamento em 2022",
                    Image = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
            };
        }
    }
}
