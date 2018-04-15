using System;
using System.Collections.Generic;
using SportsStoreSQLServer.Models;

namespace SportsStoreSQLServer.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
