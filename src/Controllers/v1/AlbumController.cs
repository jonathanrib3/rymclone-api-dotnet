using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Persistence.Context.Interfaces;

namespace RymCloneApi.src.Controllers.v1
{
  [ApiController]
  public class AlbumController : ApplicationV1Controller
  {
    private readonly IAppDbContext _context;

    public AlbumController(IAppDbContext context)
    {
      _context = context;
    }

    [HttpGet("albums")]
    public async Task<ActionResult<IEnumerable<Album>>> Index()
    {
      var albums = await _context.Albums.ToListAsync();

      if (albums.Count == 0) return NoContent();

      return albums;
    }

    [HttpGet("albums/{id:int:min(1)}")]
    public async Task<ActionResult<Album>> Show(int id)
    {
      var album = await _context.Albums.Include(e => e.Artist).Include(e => e.Genres).FirstOrDefaultAsync(album => album.Id == id);
      if (album == null) return NotFound();

      return album;
    }

    // [HttpPost("albums")]
    public async Task<ActionResult> Create([FromBody] Album album)
    {
      try
      {
        await _context.Albums.AddAsync(album);
        await _context.SaveChangesAsync();

        return Created();
      }
      catch (Exception ex)
      {
        return UnprocessableEntity(ex);
      }
    }
  }
}
