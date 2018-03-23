using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Group1_Assn4.Models
{
    public class Client
    {
    
        public int ClientID { get; set; }

        public string ClientName { get; set; }

        public string Region { get; set; }

        public ICollection<Project> Projects { get; set; }

    }// end class
}// end namespace
