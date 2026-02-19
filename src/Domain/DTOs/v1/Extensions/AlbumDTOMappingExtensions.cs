namespace RymCloneApi.src.Domain.DTOs.v1.Extensions
{
  public static class AlbumDTOMappingExtensions
  {
    public static Album FromCreateArtistRequestToAlbum(this CreateAlbumRequestDTO dto, ICollection<Genre> genres)
    {
      return new Album
      {
        Title = dto.Title,
        ReleaseDate = dto.ReleaseDate,
        ArtistId = dto.ArtistId,
        Genres = genres
      };
    }
  }
}
