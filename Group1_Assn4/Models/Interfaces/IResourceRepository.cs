 
using System.Linq;
 

namespace Group1_Assn4.Models
{
    public interface IResourceRepository
    {
         IQueryable<Resource> Resources { get; }

    }// end class
}// end namespace