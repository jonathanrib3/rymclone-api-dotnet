using RymCloneApi.src.Domain;
using RymCloneApi.src.Persistence.Context.Interfaces;
using RymCloneApi.src.Persistence.Repositories;
using RymCloneApi.src.Persistence.Repositories.Genres;

namespace RymCloneApi.src.Persistence.UnitOfWork
{
  public class UnitOfWork : IUnitOfWork, IDisposable
  {
    private readonly IAppDbContext _context;
    private IRepository<Genre> _privateGenreRepo;
    public IRepository<Genre> GenresRepository
    {
      get
      {
        return _privateGenreRepo = _privateGenreRepo ?? new GenresRepository(_context);
      }
    }

    public UnitOfWork(IAppDbContext context)
    {
      _context = context;
    }

    public async Task Commit()
    {
      _context.ChangeTracker.DetectChanges();
      if(_context.ChangeTracker.HasChanges())
      {
        await _context.SaveChangesAsync();
      }
    }
    public void Dispose()
    {
      _context.Dispose();
    }
  }
}
