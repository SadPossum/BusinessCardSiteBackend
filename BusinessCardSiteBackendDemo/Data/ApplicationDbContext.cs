using BusinessCardSiteBackendDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessCardSiteBackendDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasKey(r => r.Id);
        }
    }
}
