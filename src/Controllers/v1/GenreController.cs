using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Exceptions.UnprocessableEntityException;
using RymCloneApi.src.Persistence.Repositories;
using RymCloneApi.src.Persistence.UnitOfWork;

namespace RymCloneApi.src.Controllers.v1
{
  [ApiController]
  public class GenreController : ApplicationV1Controller
  {
    private readonly IRepository<Genre> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public GenreController(IRepository<Genre> repository, IUnitOfWork unitOfWork)
    {
      _repository = repository;
      _unitOfWork = unitOfWork;
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
      var genre = _repository.Get(g => g.Id == id);
      if (genre == null) return NotFound();

      return genre;
    }

    [HttpPost("genres")]
    public async Task<ActionResult> Create(Genre genre)
    {
      try
      {
        var test = await _repository.CreateAsync(genre);
        await _unitOfWork.Commit();

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
        _repository.Update(genre);
        await _unitOfWork.Commit();

        return Ok(genre);
      }
      catch (Exception ex)
      {
        return UnprocessableEntity(new { message = ex.Message });
      }
    }

    [HttpDelete("genres/{id:int}")]
    public async Task<ActionResult<Genre>> Destroy(int id)
    {
      var genre = _repository.Get(g => g.Id == id);
      if (genre == null) return NotFound();
      var deletedGenre = _repository.Delete(genre);
      try
      {
        await _unitOfWork.Commit();

      }
      catch (DbUpdateException ex)
      {
        throw new UnprocessableEntityException("Cannot delete a Genre that has albums - make sure to delete or modify this Genre's albums before deleting it.")
        {
          Trace = ex.StackTrace,
          Cause = ex
        };
      }

      return Ok(deletedGenre);
    }
  }
}
