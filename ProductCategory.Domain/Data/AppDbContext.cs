using Microsoft.EntityFrameworkCore;
using ProductCategory.Domain.Model;

namespace ProductCategory.Domain.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
        }

    }

}
