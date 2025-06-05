using ShoppingCartR.Models;

namespace ShoppingCartR.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
