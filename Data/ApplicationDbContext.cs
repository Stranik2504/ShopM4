using AdventureLabNew.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdventureLabNew.Data
{
    public class ApplicationDbContext : IdentityDbContext   // изменили наследоавния
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<MyModel> MyModels { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
