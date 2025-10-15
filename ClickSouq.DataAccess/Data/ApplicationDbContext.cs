using ClickSouq.Models;
using Microsoft.EntityFrameworkCore;

namespace ClickSouq.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "History", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Classical", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Geography", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Geography", DisplayOrder = 4 }
                );
        }

    }
}
