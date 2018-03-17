﻿using System;
using System.Linq;

namespace TMSSportsStore.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
