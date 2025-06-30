using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ShoppingCartR.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ShoppingCartR.Repository
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        
        }
        
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }

       public DbSet<ShoppingKart> ShoppingKarts { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

}
