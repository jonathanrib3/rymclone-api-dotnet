using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Controllers.v1.DTOs.AlbumsDTOs;
using RymCloneApi.src.Controllers.v1.DTOs.Extensions;
using RymCloneApi.src.Domain.Entities;
using RymCloneApi.src.Persistence.Repositories.Albums;
using RymCloneApi.src.Persistence.Repositories.Genres;
using RymCloneApi.src.Persistence.UnitOfWork;

namespace RymCloneApi.src.Controllers.v1
{
  [ApiController]
  public class AlbumController : ApplicationV1Controller
  {
    private readonly IAlbumsRepository _albumsRepository;
    private readonly IGenresRepository _genresRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AlbumController(IAlbumsRepository albumsRepository, IGenresRepository genresRepository, IUnitOfWork unitOfWork)
    {
      _albumsRepository = albumsRepository;
      _genresRepository = genresRepository;
      _unitOfWork = unitOfWork;
    }

    [HttpGet("albums")]
    public async Task<ActionResult<IEnumerable<AlbumResponseDTO>>> Index()
    {
      var albums = await _albumsRepository.GetAllAsync(albums => albums.Artist, albums => albums.Genres);

      if (!albums.Any()) return NoContent();
      IEnumerable<AlbumResponseDTO> albumsDTO = albums.Select<Album, AlbumResponseDTO>(album => album.FromAlbumToAlbumResponse());

      return Ok(albumsDTO);
    }

    [HttpGet("albums/{id:int:min(1)}")]
    public ActionResult<AlbumResponseDTO> Show(int id)
    {
      var album = _albumsRepository.Get(album => album.Id == id, album => album.Genres, album => album.Artist);
      if (album == null) return NotFound();

      return album.FromAlbumToAlbumResponse();
    }

    [HttpPost("albums")]
    public async Task<ActionResult> Create(CreateAlbumRequestDTO albumDTO)
    {
      var genres = _genresRepository.FindAllGenresById(albumDTO.GenresIds);
      var albums = albumDTO.FromCreateArtistRequestToAlbum(genres);
      await _albumsRepository.CreateAsync(albums);
      await _unitOfWork.Commit();

      return Created(); 
    }

    [HttpDelete("albums/{id:int:min(1)}")]
    public async Task<ActionResult<Album>> Delete(int id)
    {
      var album = _albumsRepository.Get(album => album.Id == id);
      _albumsRepository.Delete(album);
      await _unitOfWork.Commit();

      return Ok(album);
    }

    public async Task
  }
}
