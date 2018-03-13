using System;
using Microsoft.AspNetCore.Mvc;
using TMSSportsStore.Models;

namespace TMSSportsStore.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Products);

        private IProductRepository repository;
    }
}
