using RymCloneApi.src.Domain.Entities;
using RymCloneApi.src.Persistence.Context.Interfaces;
using System.Linq.Expressions;

namespace RymCloneApi.src.Persistence.Repositories.Albums
{
  public class AlbumsRepository : Repository<Album>, IAlbumsRepository
  {
    private readonly IAppDbContext _context;
    private readonly IQueryable<Album> _table;
    public AlbumsRepository(IAppDbContext context) : base(context) { }
  }
}
