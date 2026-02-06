using System;

namespace RymCloneApi.src.Domain;

public class AlbumGenre
{
  protected AlbumGenre() { }

  public AlbumGenre(int albumId, int genreId)
  {
    AlbumId = albumId;
    GenreId = genreId;
  }

  public int AlbumId { get; set; }
  public int GenreId { get; set; }
}
