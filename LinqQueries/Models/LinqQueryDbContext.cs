using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LinqQueries.Models
{
    public class LinqQueryDbContext : DbContext
    {
        public LinqQueryDbContext(DbContextOptions<LinqQueryDbContext> options) : base(options)
        {
        }
        DbSet<Client> Clients { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectResource> ProjectResources { get; set; }
        DbSet<Resource> Resources { get; set; }
    }
}
