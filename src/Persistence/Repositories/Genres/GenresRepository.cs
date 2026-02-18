using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Exceptions.NotFoundErrorException;
using RymCloneApi.src.Exceptions.UnprocessableEntityException;
using RymCloneApi.src.Persistence.Context.Interfaces;
using System.Linq.Expressions;

namespace RymCloneApi.src.Persistence.Repositories.Genres
{
  public class GenresRepository : Repository<Genre>
  {
    private readonly IAppDbContext _context;
    public GenresRepository(IAppDbContext context) : base(context)
    {
    }
  }
}
