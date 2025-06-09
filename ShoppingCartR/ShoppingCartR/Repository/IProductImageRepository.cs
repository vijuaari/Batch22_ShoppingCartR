using ShoppingCartR.Models;

namespace ShoppingCartR.Repository
{
    public interface IProductImageRepository : IRepository<ProductImage>
    {
        void Update(ProductImage obj);
    }
}
