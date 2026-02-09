using RymCloneApi.src.Providers;

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

  public int? Id { get; set; }
  public string? Name { get; set; }
  public ICollection<Album> Albums { get; set; }
}
