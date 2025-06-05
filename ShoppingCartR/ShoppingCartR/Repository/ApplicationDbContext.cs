using Microsoft.EntityFrameworkCore;
using ShoppingCartR.Models;

namespace ShoppingCartR.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        
        }
        
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }

}
