using System;

namespace RymCloneApi.src.Domain;

public class Artist
{
  protected Artist()
  {
    Albums = [];
  }

  public Artist(int id, string name, ICollection<Album>? albums)
  {
    Id = id;
    Name = name;
    Albums = albums ?? [];
  }

  public int Id { get; set; }
  public string Name { get; set; }
  public ICollection<Album> Albums { get; set; }
}
