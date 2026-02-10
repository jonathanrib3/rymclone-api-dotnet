using System.ComponentModel.DataAnnotations;

namespace RymCloneApi.src.Domain;

public class Genre
{
  protected Genre()
  {
    Albums = [];
  }

  public Genre(string name, ICollection<Album>? albums = null)
  {
    Name = name;
    Albums = albums ?? [];
  }
  [Key]
  public int? Id { get; set; }
  [Required]
  [MaxLength(100)]
  public string? Name { get; set; }
  public ICollection<Album> Albums { get; set; }
}
