using ShoppingCartR.Models;

namespace ShoppingCartR.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}
