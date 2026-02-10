using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RymCloneApi.src.Domain;

namespace RymCloneApi.src.Persistence.Context.Interfaces
{
  public interface IAppDbContext
  {
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Album> Albums { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
  }
}
