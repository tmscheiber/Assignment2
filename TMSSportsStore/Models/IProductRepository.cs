using System;
using System.Linq;

namespace TMSSportsStore.Models
{
    public interface IProductRepository
    {
        IUQueryable<Product> Products { get; }
    }
}
