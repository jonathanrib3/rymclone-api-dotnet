using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Persistence.Context.Extensions;
using RymCloneApi.src.Persistence.Context.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RymCloneApi.src.Persistence.Repositories
{
  public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    private readonly IAppDbContext _context;
    private readonly DbSet<TEntity> _table;

    public Repository(IAppDbContext context)
    {
      _context = context;
      _table = context.Set<TEntity>();
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
      await _table.AddAsync(entity);

      return entity;
    }

    public virtual TEntity Delete(TEntity entity)
    {
      _table.Remove(entity);

      return entity;
    }

    public virtual TEntity? Get(Expression<Func<TEntity, bool>> predicate)
    {
      return _table.FirstOrDefault(predicate);
    }

    public virtual TEntity? Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
    {
      return _table.IncludeMultiple(includes).FirstOrDefault(predicate);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
      return await _table.ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
    {
      return await _table.IncludeMultiple(includes).ToListAsync();
    }

    public IEnumerable<TEntity?> GetMultiple(Expression<Func<TEntity, bool>> predicate)
    {
      return  _table.Where(predicate).ToList();
    }

    public IEnumerable<TEntity?> GetMultiple(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
    {
      return _table.IncludeMultiple(includes).Where(predicate).ToList();
    }

    public virtual TEntity Update(TEntity entity)
    {
      _table.Update(entity);

      return entity;
    }
  }
}
