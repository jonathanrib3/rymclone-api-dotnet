using System;

namespace RymCloneApi.src.Domain;

public class Album
{
  public int Id { get; set; }
  public string Title { get; set; }
  public DateTime ReleaseDate { get; set; }
  public int ArtistId { get; set; }
  public Artist Artist { get; set; }

  public ICollection<Genre> Genres { get; set; }

  public Album(
    int id,
    string title,
    DateTime releaseDate,
    int artistId,
    Artist artist,
    ICollection<Genre> genres
  )
  {
    Id = id;
    Title = title;
    ReleaseDate = releaseDate;
    ArtistId = artistId;
    Artist = artist;
    Genres = genres ?? [];
  }
}
