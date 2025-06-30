using ShoppingCartR.Models;

namespace ShoppingCartR.Repository
{
    public interface IShoppingkartRepository : IRepository<ShoppingKart>
    {
        void Update(ShoppingKart obj);
    }
}
