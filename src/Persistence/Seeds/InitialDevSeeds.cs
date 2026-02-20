using System;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain.Entities;
using RymCloneApi.src.Persistence.Context;
using RymCloneApi.src.Persistence.Seeds.Interfaces;

namespace RymCloneApi.src.Persistence.Seeds;

public class InitialDevSeeds : ISeed
{
  public static void Run(DbContext context)
  {
    Artist[] artists =
    [
      new Artist { Name = "Emperor"},
      new Artist { Name = "Portishead"},
      new Artist { Name = "Magdalena bay"},
      new Artist {  Name = "Caligula" }
    ];

    Genre[] genres =
    [
      new Genre { Name = "Black metal" },
      new Genre { Name = "Trip hop" },
      new Genre { Name = "Pop" },
      new Genre { Name = "Industrial" }
    ];

    Album[] albums =
    [
      new Album
      {
        Title = "In the nightside eclipse",
        ReleaseDate = DateTime.Today,
        Artist = artists[0],
        Genres = new List<Genre> {genres[0]}
      },
      new Album
      {
        Title = "Dummy",
        ReleaseDate = DateTime.Today,
        Artist = artists[1],
        Genres = new List<Genre> {genres[1]}
      },
      new Album
      {
        Title = "Imaginal Disk",
        ReleaseDate = DateTime.Today,
        Artist = artists[2],
        Genres = new List<Genre> {genres[2]}
      },
      new Album
      {
        Title = "Caligula",
        ReleaseDate = DateTime.Today,
        Artist = artists[3],
        Genres = new List<Genre> {genres[3]}
      },
    ];

    foreach (Artist artist in artists)
    {
      context.Add<Artist>(artist);
    }
    foreach (Genre genre in genres)
    {
      context.Add<Genre>(genre);
    }
    foreach (Album album in albums)
    {
      context.Add<Album>(album);
    }
  }

  public static bool ShouldSeed(DbContext context)
  {
    var anyArtists = context.Set<Artist>().Any();
    var anyGenres = context.Set<Genre>().Any();
    var anyAlbums = context.Set<Album>().Any();

    return !anyArtists && !anyGenres && !anyAlbums;
  }
}
