using System;
namespace LinqQueries.Models
{
    public class Project
    {
        public Project()
        {
        }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int ClientID { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime KickoffDate { get; set; }
        public string Status { get; set; }
        public decimal Revenue { get; set; }
    }
}
