using ShoppingCartR.Models;

namespace ShoppingCartR.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ApplicationDbContext _db;
         public ProductRepository (ApplicationDbContext db) : base (db)
        {
            _db = db;
        }

        public void Update (Product obj)
        {
            _db.Product.Update(obj);
        }
    }
}
