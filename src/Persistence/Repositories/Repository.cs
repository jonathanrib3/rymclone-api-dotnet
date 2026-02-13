using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Exceptions.UnprocessableEntityException;
using RymCloneApi.src.Persistence.Context.Interfaces;
using System.Linq.Expressions;

namespace RymCloneApi.src.Persistence.Repositories
{
  public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    private readonly IAppDbContext _context;

    public Repository(IAppDbContext context)
    {
      _context = context;
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
      await _context.Set<TEntity>().AddAsync(entity);

      return entity;
    }

    public TEntity Delete(TEntity entity)
    {
      _context.Set<TEntity>().Remove(entity);

      return entity;
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
    {
      return _context.Set<TEntity>().FirstOrDefault();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
      return await _context.Set<TEntity>().ToListAsync();
    }

    public TEntity Update(TEntity entity)
    {
      _context.Set<TEntity>().Update(entity);

      return entity;
    }
  }
}
