using System;
namespace LinqQueries.Models
{
    public class Resource
    {
        public Resource()
        {
        }
        public int ResourceID { get; set; }
        public string ResourceName { get; set; }
        public decimal HourlyRate { get; set; }
        public int ServiceYears { get; set; }
        public string Role { get; set; }
    }
}
