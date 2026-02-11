using RymCloneApi.src.Persistence.Context.Interfaces;
using System.Linq.Expressions;

namespace RymCloneApi.src.Persistence.Repositories
{
  public interface IRepository<T> where T : class
  {
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> Get(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
  }
}
