using System;
namespace TMSSportsStore.Models
{
    public class Product
    {
        public Product()
        {
        }

        public int ProductID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public decimal Price
        {
            get;
            set;
        }
        public string Category
        {
            get;
            set;
        }
    }
}
