using RymCloneApi.src.Domain.DTOs.v1;

namespace RymCloneApi.src.Domain.DTOs.v1.Extensions
{
  public static class ArtistDTOMappingExtensions
  {
    public static Artist FromCreateArtistRequestToArtist(this CreateArtistRequestDTO dto)
    {
      return new Artist
      {
        Name = dto.Name
      };
    }
  }
}
