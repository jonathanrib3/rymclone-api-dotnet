using RymCloneApi.src.Domain.DTOs.v1;

namespace RymCloneApi.src.Domain.DTOs.v1.Extensions
{
  public static class GenreDTOMappingExtensions
  {
    public static Genre FromCreateGenreRequestToGenre(this CreateGenreRequestDTO dto)
    {
      return new Genre
      {
        Name = dto.Name
      };
    }
  }
}
