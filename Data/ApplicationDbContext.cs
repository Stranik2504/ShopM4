using AdventureLabNew.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureLabNew.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<MyModel> MyModels { get; set; }

        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
