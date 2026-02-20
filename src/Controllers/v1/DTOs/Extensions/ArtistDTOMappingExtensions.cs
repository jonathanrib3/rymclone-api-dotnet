using RymCloneApi.src.Controllers.v1.DTOs.ArtistsDTOs;
using RymCloneApi.src.Domain.Entities;

namespace RymCloneApi.src.Controllers.v1.DTOs.Extensions
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
