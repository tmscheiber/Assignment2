using System.Collections.Generic;
using System.Linq;

namespace Group1_Assn4.Models
{
    public class EFResourceRepository : IResourceRepository
    {
        private ApplicationDbContext context;
        public EFResourceRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Resource> Resources => context.Resources;
    }// end class

}// end namespace
