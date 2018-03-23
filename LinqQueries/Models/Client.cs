using System;
using System.Linq;

namespace LinqQueries.Models
{
    public class Client
    {
        public Client()
        {
        }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string Region { get; set; }
    }
}
