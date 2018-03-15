using System;
using Microsoft.AspNetCore.Mvc;
using TMSSportsStore.Models;
using System.Linq;

namespace TMSSportsStore.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int productPage = 1) => View(repository.Products.OrderBy(p => p.ProductID).Skip((productPage - 1) * PageSize).Take(PageSize));

        private IProductRepository repository;
        public int PageSize = 4;
    }
}
