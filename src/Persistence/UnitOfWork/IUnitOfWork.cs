using RymCloneApi.src.Domain;
using RymCloneApi.src.Persistence.Repositories;
using RymCloneApi.src.Persistence.Repositories.Genres;

namespace RymCloneApi.src.Persistence.UnitOfWork
{
  public interface IUnitOfWork
  {
    IRepository<Genre> GenresRepository { get; }

    Task Commit();
  }
}
