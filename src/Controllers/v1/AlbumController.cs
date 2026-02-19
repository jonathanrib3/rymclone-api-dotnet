using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Domain.DTOs.v1;
using RymCloneApi.src.Exceptions.NotFoundErrorException;
using RymCloneApi.src.Persistence.Context.Interfaces;
using RymCloneApi.src.Persistence.Repositories;
using RymCloneApi.src.Persistence.UnitOfWork;
using System.Net;

namespace RymCloneApi.src.Controllers.v1
{
  [ApiController]
  public class AlbumController : ApplicationV1Controller
  {
    private readonly Repository<Album> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AlbumController(Repository<Album> repository, IUnitOfWork unitOfWork)
    {
      _repository = repository;
      _unitOfWork = unitOfWork;
    }

    [HttpGet("albums")]
    public async Task<ActionResult<IEnumerable<Album>>> Index()
    {
      var albums = await _repository.GetAllAsync(albums => albums.Artist, albums => albums.Genres);

      if (!albums.Any()) return NoContent();

      return Ok(albums);
    }

    //[HttpGet("albums/{id:int:min(1)}")]
    //public async Task<ActionResult<Album>> Show(int id)
    //{
    //  var album = await _context.Albums.Include(e => e.Artist).Include(e => e.Genres).FirstOrDefaultAsync(album => album.Id == id);
    //  if (album == null) throw new NotFoundException($"Album with ID {id} not found");

    //  return album;
    //}

    //[HttpPost("albums")]
    //public async Task<ActionResult> Create(CreateAlbumRequestDTO albumDTO)
    //{

    //  var genres = _context.Albums.Where(al => al.Id == 1 || al.Id == 2 || al.Id == 3);

    //  await _context.Albums.AddAsync(album);
    //  await _context.SaveChangesAsync();

    //  return Ok(genres);
    //}
  }
}
