using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Controllers.v1.DTOs.AlbumsDTOs;
using RymCloneApi.src.Controllers.v1.DTOs.Extensions;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Domain.Entities;
using RymCloneApi.src.Domain.Validators;
using RymCloneApi.src.Persistence.Repositories.Albums;
using RymCloneApi.src.Persistence.Repositories.Artists;
using RymCloneApi.src.Persistence.Repositories.Genres;
using RymCloneApi.src.Persistence.Repositories.Reviews;
using RymCloneApi.src.Persistence.UnitOfWork;

namespace RymCloneApi.src.Controllers.v1
{
  [ApiController]
  public class ReviewController : ApplicationV1Controller
  {
    private readonly IReviewsRepository _reviewsRepository;
    private readonly IAlbumsRepository _albumsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewController(IReviewsRepository reviewsRepository, IAlbumsRepository albumsRepository, IUnitOfWork unitOfWork)
    {
      _reviewsRepository = reviewsRepository;
      _albumsRepository = albumsRepository;
      _unitOfWork = unitOfWork;
    }

    [HttpGet("reviews")]
    public async Task<ActionResult<IEnumerable<Review>>> Index()
    {
      var reviews = await _reviewsRepository.GetAllAsync(reviews => reviews.Album, reviews => reviews.User);

      if (!reviews.Any()) return NoContent();
      //IEnumerable<AlbumResponseDTO> albumsDTO = albums.Select<Album, AlbumResponseDTO>(album => album.FromAlbumToAlbumResponse());

      return Ok(reviews);
    }

    //[HttpGet("albums/{id:int:min(1)}")]
    //public ActionResult<AlbumResponseDTO> Show(int id)
    //{
    //  var album = _albumsRepository.Get(album => album.Id == id, album => album.Genres, album => album.Artist);
    //  if (album == null) return NotFound();

    //  return album.FromAlbumToAlbumResponse();
    //}

    //[HttpPost("albums")]
    //public async Task<ActionResult> Create(CreateAlbumRequestDTO albumDTO)
    //{
    //  var genres = _genresRepository.FindAllGenresById(albumDTO.GenresIds);
    //  var albums = albumDTO.FromCreateArtistRequestToAlbum(genres);
    //  await _albumsRepository.CreateAsync(albums);
    //  await _unitOfWork.Commit();

    //  return Created(); 
    //}

    //[HttpDelete("albums/{id:int:min(1)}")]
    //public async Task<ActionResult<Album>> Delete(int id)
    //{
    //  var album = _albumsRepository.Get(album => album.Id == id);
    //  _albumsRepository.Delete(album);
    //  await _unitOfWork.Commit();

    //  return Ok(album);
    //}

    //[HttpPatch("albums/{id:int:min(1)}")]
    //[Consumes("application/json-patch+json")]
    //public async Task<ActionResult<AlbumResponseDTO>> PartialUpdate(int id, [FromBody] JsonPatchDocument<UpdateAlbumRequestDTO> patchAlbumRequest)
    //{
    //  var album = _albumsRepository.Get(album => album.Id == id, album => album.Artist, album => album.Genres);
    //  var albumAsDTO = album.FromAlbumToUpdateAlbumRequest();
    //  if (album == null) return NotFound();
    //  patchAlbumRequest.ApplyTo(albumAsDTO);
    //  var genres = _genresRepository.FindAllGenresById(albumAsDTO.GenresIds);
    //  var artist = _artistsRepository.Get(artist => artist.Id == albumAsDTO.ArtistId);
    //  album.Artist = artist;
    //  album.Genres = genres.ToList();
    //  _albumsRepository.Update(album);
    //  new AlbumValidator().ValidateAndThrow(album);
    //  await _unitOfWork.Commit();

    //  return Ok(album.FromAlbumToAlbumResponse());
    //}
  }
}
