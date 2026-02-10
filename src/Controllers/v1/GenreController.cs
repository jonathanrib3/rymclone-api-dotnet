using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Persistence.Context;
using RymCloneApi.src.Persistence.Context.Interfaces;

namespace RymCloneApi.src.Controllers.v1
{
  [ApiController]
  public class GenreController : ApplicationV1Controller
  {
    private readonly IAppDbContext _context;

    public GenreController(IAppDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    [Route("genres")]
    public async Task<ActionResult<IEnumerable<Genre>>> Index()
    {
      List<Genre> genres = await _context.Genres.ToListAsync();

      if (genres.Count == 0)
      {
        return NoContent();
      }

      return genres;
    }

    [HttpGet]
    [Route("genres/{id:int}", Name = "ShowAlbum")]
    public async Task<ActionResult<Genre>> Show(int id)
    {
      var genre = await _context.Genres.FirstOrDefaultAsync(genre => genre.Id == id);
      if (genre == null) return NotFound();

      return genre;
    }

    [HttpPost("genres")]
    public async Task<ActionResult> Create(Genre genre)
    {
      try
      {
        var test = await _context.Genres.AddAsync(genre);
        await _context.SaveChangesAsync();

        return Created();
      }
      catch (Exception ex)
      {
        return UnprocessableEntity(new { message = ex.Message });
      }
    }

    [HttpPut("genres/{id:int:min(1)}")]
    public async Task<ActionResult> Update(int id, Genre genre)
    {
      try
      {
        _context.Genres.Entry(genre).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(genre);
      }
      catch (Exception ex)
      {
        return UnprocessableEntity(new { message = ex.Message });
      }
    }

    [HttpDelete("genres/{id:int}")]
    public async Task<ActionResult> Destroy(int id)
    {
      var genre = await _context.Genres.FirstOrDefaultAsync(e => e.Id == id);

      if(genre == null) return NotFound();

      _context.Genres.Remove(genre);
      await _context.SaveChangesAsync();

      return Ok(genre);
    }
  }
}
