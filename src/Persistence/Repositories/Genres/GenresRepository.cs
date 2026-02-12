using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Exceptions.NotFoundErrorException;
using RymCloneApi.src.Exceptions.UnprocessableEntityException;
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
    public async Task<Genre> CreateAsync(Genre genre)
    {
      await _context.Genres.AddAsync(genre);
      await _context.SaveChangesAsync();

      return genre;
    }

    public async Task<IEnumerable<Genre>> GetAllAsync()
    {
      return await _context.Genres.AsNoTracking().ToListAsync() ?? [];
    }

    public async Task<Genre?> Get(Expression<Func<Genre, bool>> predicate)
    {
      return await _context.Set<Genre>().Include(g => g.Albums).FirstOrDefaultAsync(predicate);
    }

    public async Task<Genre> UpdateAsync(Genre genre)
    {
      _context.Genres.Entry(genre).State = EntityState.Modified;
      await  _context.SaveChangesAsync();

      return genre;
    }

    public async Task<bool> DeleteAsync(int id)
    {
      try
      {
        var genre = await _context.Genres.FindAsync(id);
        if (genre == null) throw new NotFoundException(message: $"Genre with id {id} does not exist");
        _context.Genres.Remove(genre);
        var affectedRows = await _context.SaveChangesAsync();

        return affectedRows > 0;
      }
      catch (DbUpdateException ex)
      {
        throw new UnprocessableEntityException("Cannot delete a Genre that has albums - make sure to delete or modify this Genre's albums before deleting it.")
        {
          Trace = ex.StackTrace,
          Cause = ex
        };
      }

    }
  }
}
