using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Persistence.Context;

namespace RymCloneApi.src.Controllers
{
  [ApiController]
  [Route("genres")]
  public class GenreController : ControllerBase
  {
    private readonly AppDbContext _context;

    public GenreController(AppDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Genre>>> Index()
    {
      List<Genre> genres = await _context.Genres.ToListAsync();

      return genres;
    }
  }
}
