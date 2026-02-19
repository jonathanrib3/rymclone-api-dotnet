using RymCloneApi.src.Domain;
using RymCloneApi.src.Persistence.Context.Interfaces;

namespace RymCloneApi.src.Persistence.Repositories.Albums
{
  public class AlbumsRepository : Repository<Album>
  {
    public AlbumsRepository(IAppDbContext context) : base(context) { }
  }
}
