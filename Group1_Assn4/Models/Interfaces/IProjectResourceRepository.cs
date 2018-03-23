 
using System.Linq;
 

namespace Group1_Assn4.Models
{
    public interface IProjectResourceRepository
    {
         IQueryable<ProjectResource> ProjectResources { get; }

    }// end class

 



}// end namespace