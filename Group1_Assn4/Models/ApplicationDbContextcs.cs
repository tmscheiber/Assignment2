using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Group1_Assn4.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
       public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Resource> Resources { get; set; }

        public DbSet<ProjectResource> ProjectResources { get; set; }



    }// end class
}// end namespace
