using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Group1_Assn4.Models
{
    public class Resource
    {
         
        public int ResourceID { get; set; }

        [Display(Name = "Resource Name")]
        public string ResourceName { get; set; }

        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate { get; set; }

        [Display(Name = "Service Years")]
        public int ServiceYears { get; set; }

        public string Role { get; set; }

   
    }// end class
}// end namespace
