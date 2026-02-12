using RymCloneApi.src.Persistence.Context.Interfaces;
using System.Linq.Expressions;

namespace RymCloneApi.src.Persistence.Repositories
{
  public interface IRepository<T> where T : class
  {
    Task<IEnumerable<T>> GetAllAsync();
    T? Get(Expression<Func<T, bool>> predicate);
    Task<T> CreateAsync(T entity);
    T Update(T entity);
    T Delete(T entity);
  }
}
