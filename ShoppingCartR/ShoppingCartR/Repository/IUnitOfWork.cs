namespace ShoppingCartR.Repository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IProductImageRepository ProductImage { get; }

        IShoppingkartRepository Shoppingkart { get; }
        void Save();
    }
}
