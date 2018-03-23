 
using System.Linq;
 

namespace Group1_Assn4.Models
{
    public interface IClientRepository
    {
         IQueryable<Client> Clients { get; }

    }// end class

}// end namespace