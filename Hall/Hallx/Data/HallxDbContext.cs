using Hallx.Models;
using Microsoft.EntityFrameworkCore;

namespace Hallx.Data
{
    public class HallxDbContext : DbContext
    {
        public HallxDbContext(DbContextOptions<HallxDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Toys", DisplayOrder=6},
                new Category { Id=2, Name="Soap", DisplayOrder=7},
                new Category { Id=3, Name="Hamper", DisplayOrder=9});

        }
    }
}
