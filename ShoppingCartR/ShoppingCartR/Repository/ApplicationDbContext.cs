using Microsoft.EntityFrameworkCore;

namespace ShoppingCartR.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }     
    }
}
