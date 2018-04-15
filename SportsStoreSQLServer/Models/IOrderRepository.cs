using System;
using System.Linq;

namespace SportsStoreSQLServer.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
