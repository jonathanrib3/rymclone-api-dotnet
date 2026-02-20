using RymCloneApi.src.Domain.Entities;
using RymCloneApi.src.Controllers.v1.DTOs.AlbumsDTOs;
namespace RymCloneApi.src.Controllers.v1.DTOs.Extensions
{
  public static class AlbumDTOMappingExtensions
  {
    public static Album FromCreateArtistRequestToAlbum(this CreateAlbumRequestDTO dto, IEnumerable<Genre> genres)
    {
      return new Album
      {
        Title = dto.Title,
        ReleaseDate = dto.ReleaseDate,
        ArtistId = dto.ArtistId,
        Genres = genres.ToList()
      };
    }
    public static AlbumResponseDTO FromAlbumToAlbumResponse(this Album album)
    {
      var genres = album.Genres.Select(genre =>
      {
        return new AlbumGenreResponseDTO
        {
          Id = genre.Id,
          Name = genre.Name
        };
      });

      return new AlbumResponseDTO
      {
        Id = album.Id,
        Title = album.Title,
        ReleaseDate = album.ReleaseDate,
        Artist = new AlbumArtistResponseDTO 
        { 
          Id = album.Artist.Id,
          Name = album.Artist.Name
        },
        Genres = genres
      };
    }
  }
}
