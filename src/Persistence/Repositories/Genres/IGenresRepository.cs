using RymCloneApi.src.Domain.Entities;

namespace RymCloneApi.src.Persistence.Repositories.Genres
{
  public interface IGenresRepository : IRepository<Genre>
  {
    IEnumerable<Genre> FindAllGenresById(IEnumerable<int> genresIds);
  }
}
