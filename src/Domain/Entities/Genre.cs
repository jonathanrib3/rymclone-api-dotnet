using System.ComponentModel.DataAnnotations;

namespace RymCloneApi.src.Domain.Entities;

public class Genre
{
  public Genre()
  {
    Albums = [];
  }

  public int? Id { get; set; }
  public string? Name { get; set; }
  public ICollection<Album> Albums { get; set; }
}
