 
using System.Linq;
 

namespace Group1_Assn4.Models
{
    public interface IProjectRepository
    {
         IQueryable<Project> Projects { get; }

    }// end class

}// end namespace