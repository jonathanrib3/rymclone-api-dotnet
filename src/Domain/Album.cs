using System;

namespace RymCloneApi.src.Domain;

public class Album
{
  protected Album()
  {
    Genres = [];
  }

  public Album(int id, string title, DateTime releaseDate, Artist artist, ICollection<Genre> genres)
  {
    Id = id;
    Title = title;
    ReleaseDate = releaseDate;
    Artist = artist;
    ArtistId = artist.Id;
    Genres = genres ?? [];
  }

  public int Id { get; set; }
  public string Title { get; set; }
  public DateTime ReleaseDate { get; set; }
  public int ArtistId { get; set; }
  public Artist Artist { get; set; }

  public ICollection<Genre> Genres { get; set; }
}
