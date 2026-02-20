using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using RymCloneApi.src.Domain.Entities;

namespace RymCloneApi.src.Persistence.Context.Interfaces
{
  public interface IAppDbContext
  {
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Album> Albums { get; set; }
    public ChangeTracker ChangeTracker { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    abstract int SaveChanges();
    abstract DbSet<TEntity> Set<TEntity>() where TEntity : class;
    void Dispose();
  }
}
