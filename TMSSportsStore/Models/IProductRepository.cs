using System;
using System.Linq;

namespace TMSSportsStore.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
