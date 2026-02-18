using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Domain.DTOs.v1;
using RymCloneApi.src.Domain.DTOs.v1.Extensions;
using RymCloneApi.src.Domain.Validators;
using RymCloneApi.src.Persistence.Context.Interfaces;
using RymCloneApi.src.Persistence.Repositories;
using RymCloneApi.src.Persistence.UnitOfWork;
using System.Threading.Tasks;

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
  }
}
