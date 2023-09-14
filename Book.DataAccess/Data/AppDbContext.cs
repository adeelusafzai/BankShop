using Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Book.DataAccess.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category { ID=1, Name="Action", DisplayOrder=1  },
            new Category { ID = 2, Name = "Sci Fi", DisplayOrder = 2 },
            new Category { ID = 3, Name = "History", DisplayOrder = 3 }
            );
        }
    }
}
