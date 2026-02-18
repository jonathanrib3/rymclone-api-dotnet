using RymCloneApi.src.Domain;
using RymCloneApi.src.Persistence.Context.Interfaces;

namespace RymCloneApi.src.Persistence.Repositories.Artists
{
  public class ArtistsRepository : Repository<Artist>
  {
    private readonly IAppDbContext _context;
    public ArtistsRepository(IAppDbContext context) : base(context)
    {
    }
  }
}
