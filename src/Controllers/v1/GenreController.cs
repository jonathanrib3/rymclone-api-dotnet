using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Persistence.Repositories;

namespace RymCloneApi.src.Controllers.v1
{
  [ApiController]
  public class GenreController : ApplicationV1Controller
  {
    private readonly IRepository<Genre> _repository;

    public GenreController(IRepository<Genre> repository)
    {
      _repository = repository;
    }

    [HttpGet]
    [Route("genres")]
    public async Task<ActionResult<IEnumerable<Genre>>> Index()
    {
      var genres = await _repository.GetAllAsync();

      if (!genres.Any())
      {
        return NoContent();
      }

      return Ok(genres);
    }

    [HttpGet]
    [Route("genres/{id:int}")]
    public async Task<ActionResult<Genre>> Show(int id)
    {
      var genre = await _repository.Get(g => g.Id == id);
      if (genre == null) return NotFound();

      return genre;
    }

    [HttpPost("genres")]
    public async Task<ActionResult> Create(Genre genre)
    {
      try
      {
        var test = await _repository.AddAsync(genre);

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
        await _repository.UpdateAsync(genre);

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
      var result = await _repository.DeleteAsync(id);

      return result ? Ok(result) : UnprocessableEntity();
    }
  }
}
