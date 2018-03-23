using System.Collections.Generic;
using System.Linq;

namespace Group1_Assn4.Models
{
    public class EFProjectRepository : IProjectRepository
    {
        private ApplicationDbContext context;
        public EFProjectRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Project> Projects => context.Projects;
        public IQueryable<Client> Clients => context.Clients;
    }// end class

}// end namespace
