using RymCloneApi.src.Controllers.v1.DTOs.GenresDTOs;
using RymCloneApi.src.Domain.Entities;

namespace RymCloneApi.src.Controllers.v1.DTOs.Extensions
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
