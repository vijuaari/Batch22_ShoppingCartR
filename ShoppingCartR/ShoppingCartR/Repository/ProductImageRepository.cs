using ShoppingCartR.Models;

namespace ShoppingCartR.Repository
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        public ApplicationDbContext _db;
         public ProductImageRepository(ApplicationDbContext db) : base (db)
        {
            _db = db;
        }

        public void Update (ProductImage obj)
        {
            _db.ProductImage.Update(obj);
        }
    }
}
