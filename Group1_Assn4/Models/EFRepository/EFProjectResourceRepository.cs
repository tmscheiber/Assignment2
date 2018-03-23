using System.Collections.Generic;
using System.Linq;

namespace Group1_Assn4.Models
{
    public class EFProjectResourceRepository : IProjectResourceRepository
    {
        private ApplicationDbContext context;
        public EFProjectResourceRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<ProjectResource> ProjectResources => context.ProjectResources;
    }// end class

}// end namespace
