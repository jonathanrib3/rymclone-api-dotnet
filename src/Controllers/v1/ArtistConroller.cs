using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Persistence.Context.Interfaces;

namespace RymCloneApi.src.Controllers.v1
{
  [ApiController]
  public class ArtistController : ApplicationV1Controller
  {
    private readonly IAppDbContext _context;

    public ArtistController(IAppDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    [Route("artists")]
    public async Task<ActionResult<IEnumerable<Artist>>> Index()
    {
      var artists = await _context.Artists.ToListAsync();

      if (artists.Count == 0) return NoContent();
    
      return artists;
    }
  }
}
