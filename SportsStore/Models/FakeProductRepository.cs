using System;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public FakeProductRepository()
        {
        }

        public IQueryable<Product> Products => new List<Product>
        {
            new Product { Name = "Football", Price = 25 },
            new Product { Name = "Surf Board", Price = 179 },
            new Product { Name = "Running Shoes", Price = 95 }
        }.AsQueryable<Product>();

        public void SaveProduct(Product product){}

        public Product DeleteProduct(int ProductID) { return null; }
    }
}
