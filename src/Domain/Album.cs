using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RymCloneApi.src.Domain;

public class Album
{
  public Album()
  {
    Genres = [];
  }

  [Key]
  public int? Id { get; set; }
  [Required]
  [MaxLength(250)]
  public string? Title { get; set; }
  [Required]
  public DateTime? ReleaseDate { get; set; }
  
  [JsonIgnore]
  public int? ArtistId { get; set; }

  public Artist? Artist { get; set; }

  public ICollection<Genre> Genres { get; set; }
}
