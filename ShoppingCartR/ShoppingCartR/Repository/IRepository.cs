using System.Linq.Expressions;

namespace ShoppingCartR.Repository
{
    public interface IRepository<T> where  T : class
    {
        IEnumerable<T> GetAllexpression(Expression<Func<T, bool>> filter = null, string? includeproperties = null);
        
        T Get (Expression<Func<T, bool>>filter =null, string? includeproperties = null, bool tracked = false);

        void Add (T entity);
        void Remove (T entity);
        
        void RemoveRange (IEnumerable<T> entities);

        
      }
}
