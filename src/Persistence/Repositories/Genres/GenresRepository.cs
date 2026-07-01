using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain.Entities;
using RymCloneApi.src.Exceptions.NotFoundErrorException;
using RymCloneApi.src.Exceptions.UnprocessableEntityException;
using RymCloneApi.src.Persistence.Context.Interfaces;
using System.Linq.Expressions;
using System.Linq;
namespace RymCloneApi.src.Persistence.Repositories.Genres
{
  public class GenresRepository : Repository<Genre>, IGenresRepository
  {
    public GenresRepository(IAppDbContext context) : base(context)
    {
    }

    public IEnumerable<Genre> FindAllGenresById(IEnumerable<int> genresIds)
    {
      return _table.Where(g => genresIds.ToList().Contains((int)g.Id)).ToList();
    }
  }
}
