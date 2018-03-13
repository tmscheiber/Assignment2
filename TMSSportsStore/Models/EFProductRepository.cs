using System;
using System.Collections.Generic;
using System.Linq;

namespace TMSSportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        public EFProductRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Products;
        private ApplicationDBContext context;
    }
}
