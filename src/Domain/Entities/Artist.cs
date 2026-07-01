using System;
using System.ComponentModel.DataAnnotations;

namespace RymCloneApi.src.Domain.Entities
{
  public class Artist
  {
    public Artist()
    {
      Albums = [];
    }

    [Key]
    public int? Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public ICollection<Album> Albums { get; set; }
  }
}