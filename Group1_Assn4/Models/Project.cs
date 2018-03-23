using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group1_Assn4.Models
{
    public class Project
    {
        
      
        public int ProjectID { get; set; }

        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        public int ClientID { get; set; }
        public Client Client { get; set; }

    
        [Display(Name = "Kick Off Date")]
        public DateTime KickOffDate { get; set; }

  
        [Display(Name = "Delivery Date")]
        public DateTime DeliveryDate { get; set; }

 
        public string Status { get; set; }

        public decimal Revenue { get; set; }

 

    }// end class
}// end namespace 