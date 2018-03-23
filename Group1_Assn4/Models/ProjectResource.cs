using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Group1_Assn4.Models
{
    public class ProjectResource
    {
       
        public int ProjectResourceID { get; set; }

  
        public int ProjectID { get; set; }
        public Project Project { get; set; }

       
       public int ResourceID { get; set; }
        public Resource Resource { get; set; }

        [Display(Name = "Allocated Hours")]
        public int AllocatedHours { get; set; }
    }// end class
}// end namespace