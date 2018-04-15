using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SportsStoreSQLServer.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().HasKey(EntityState => EntityState.ProductID).HasName("PK_ProductID");
        //    modelBuilder.Entity<Order>().HasKey(EntityState => EntityState.OrderID).HasName("PK_OrderID");
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=SportsStoreSQLServer.db"); //Configuration["Data:SportStoreProducts:ConnectionString"]);
        //}
    }
}
