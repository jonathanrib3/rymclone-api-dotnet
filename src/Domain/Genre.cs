using RymCloneApi.src.Providers;

namespace RymCloneApi.src.Domain;

public class Genre
{
  protected Genre()
  {
    Albums = [];
  }

  public Genre(int id, string name, ICollection<Album>? albums)
  {
    Id = id;
    Name = name;
    Albums = albums ?? [];
  }

  public int Id { get; set; }
  public string Name { get; set; }
  public ICollection<Album> Albums { get; set; }
}
