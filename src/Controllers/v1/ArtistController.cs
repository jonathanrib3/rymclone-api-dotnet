using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Controllers.v1.DTOs.ArtistsDTOs;
using RymCloneApi.src.Controllers.v1.DTOs.Extensions;
using RymCloneApi.src.Domain.Entities;
using RymCloneApi.src.Domain.Validators;
using RymCloneApi.src.Exceptions.UnprocessableEntityException;
using RymCloneApi.src.Persistence.Repositories;
using RymCloneApi.src.Persistence.UnitOfWork;

namespace RymCloneApi.src.Controllers.v1
{
  [ApiController]
  public class ArtistController : ApplicationV1Controller
  {
    private readonly IRepository<Artist> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ArtistController(IRepository<Artist> repository, IUnitOfWork unitOfWork)
    {
      _repository = repository;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [Route("artists")]
    public async Task<ActionResult<IEnumerable<Artist>>> Index()
    {
      var artists = await _repository.GetAllAsync();

      if (!artists.Any()) return NoContent();
    
      return Ok(artists);
    }

    [HttpGet("artists/{id:int:min(1)}")]
    public ActionResult<Artist> Show(int id)
    {
      var artist = _repository.Get(ar => ar.Id == id, ar => ar.Albums);
      if (artist == null) return NotFound();

      return Ok(artist);
    }

    [HttpPost("artists")]
    public async Task<ActionResult<Artist>> Create(CreateArtistRequestDTO artistDTO)
    {
      var artist = artistDTO.FromCreateArtistRequestToArtist();
      new ArtistValidator().ValidateAndThrow(artist);
      await _repository.CreateAsync(artist);
      await _unitOfWork.Commit();

      return Ok(artist);
    }

    [HttpPut("artists/{id:int:min(1)}")]
    public async Task<ActionResult<Artist>> Update(int id, UpdateArtistRequestDTO artistDTO)
    {
      var artist = _repository.Get(ar => ar.Id == id);
      if (artist == null) return NotFound();
      artist.Name = artistDTO.Name;
      new ArtistValidator().ValidateAndThrow(artist);
      _repository.Update(artist);
      await _unitOfWork.Commit();

      return Ok(artist);
    }

    [HttpDelete("artists/{id:int:min(1)}")]
    public async Task<ActionResult<Artist>> Destroy(int id)
    {
      var artist = _repository.Get(ar => ar.Id == id);
      if (artist == null) return NotFound();
      _repository.Delete(artist);
      try
      {
        await _unitOfWork.Commit();
      }
      catch (DbUpdateException ex)
      {
        throw new UnprocessableEntityException("Cannot delete an Artist that has albums - make sure to delete or modify this Artist's albums before deleting it.")
        {
          Trace = ex.StackTrace,
          Cause = ex
        };
      }

      return Ok(artist);
    }
  }
}
