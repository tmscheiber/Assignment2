using System.Collections.Generic;
using System.Linq;

namespace Group1_Assn4.Models
{
    public class EFClientRepository : IClientRepository
    {
        private ApplicationDbContext context;
        public EFClientRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Client> Clients => context.Clients;
    }// end class
}// end namespace
