﻿using System;
using System.Collections.Generic;
using TMSSportsStore.Models;

namespace TMSSportsStore.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
