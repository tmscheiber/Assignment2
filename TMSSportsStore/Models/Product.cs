using System;
namespace TMSSportsStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public sgtring Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product()
        {
        }
    }
}
