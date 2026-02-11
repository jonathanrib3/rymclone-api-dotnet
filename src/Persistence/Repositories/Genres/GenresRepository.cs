using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Persistence.Context.Interfaces;
using System.Linq.Expressions;

namespace RymCloneApi.src.Persistence.Repositories.Genres
{
  public class GenresRepository : IGenresRepository
  {
    private readonly IAppDbContext _context;
    public GenresRepository(IAppDbContext context) 
    {
      _context = context;
    }
    public async Task<Genre> AddAsync(Genre genre)
    {
      await _context.Genres.AddAsync(genre);
      await _context.SaveChangesAsync();

      return genre;
    }

    public async Task<IEnumerable<Genre>> GetAllAsync()
    {
      return await _context.Genres.ToListAsync() ?? [];
    }

    //public async Task<Genre?> GetByIdAsync(int id)
    //{
    //  return await _context.Genres.FindAsync(id);
    //}

    public async Task<Genre> Get(Expression<Func<Genre, bool>> predicate)
    {
      // implementar o método de set no context na interface.
      //return _context.Set<>
    }

    public async Task<Genre> UpdateAsync(Genre genre)
    {
      _context.Genres.Entry(genre).State = EntityState.Modified;
      await  _context.SaveChangesAsync();

      return genre;
    }

    public async Task<bool> DeleteAsync(int id)
    {
      var genre = await _context.Genres.FindAsync(id);
      _context.Genres.Remove(genre);
      var affectedRows = await _context.SaveChangesAsync();

      return affectedRows > 0;
    }
  }
}
