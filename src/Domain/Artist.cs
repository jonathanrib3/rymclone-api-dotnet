using System;
using System.ComponentModel.DataAnnotations;

namespace RymCloneApi.src.Domain;

public class Artist
{
  protected Artist()
  {
    Albums = [];
  }

  public Artist(string name, ICollection<Album>? albums = null)
  {
    Name = name;
    Albums = albums ?? [];
  }
  [Key]
  public int? Id { get; set; }
  [Required]
  public string? Name { get; set; }
  public ICollection<Album> Albums { get; set; }
}
