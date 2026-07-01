using RymCloneApi.src.Persistence.Context.Interfaces;
using System.Linq.Expressions;

namespace RymCloneApi.src.Persistence.Repositories
{
  public interface IRepository<T> where T : class
  {
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
    T? Get(Expression<Func<T, bool>> predicate);
    T? Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    IEnumerable<T>? GetMultiple(Expression<Func<T, bool>> predicate);
    IEnumerable<T>? GetMultiple(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    Task<T> CreateAsync(T entity);
    T Update(T entity);
    T Delete(T entity);
  }
}
