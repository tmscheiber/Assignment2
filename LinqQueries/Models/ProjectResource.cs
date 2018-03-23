using System;
namespace LinqQueries.Models
{
    public class ProjectResource
    {
        public ProjectResource()
        {
        }
        public int ProjectResourceID { get; set; }
        public int ProjectID { get; set; }
        public int ResourceID { get; set; }
        public int AllocatedHours { get; set; }
    }
}
