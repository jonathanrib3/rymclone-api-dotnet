using System;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Persistence.Context;
using RymCloneApi.src.Persistence.Seeds.Interfaces;

namespace RymCloneApi.src.Persistence.Seeds;

public class InitialDevSeeds : ISeed
{
  public static void Run(DbContext context)
  {
    Artist[] artists =
    [
      new(name: "Emperor"),
      new(name: "Portishead"),
      new(name: "Magdalena bay"),
      new(name: "Caligula"),
    ];

    Genre[] genres =
    [
      new(name: "Black metal"),
      new(name: "Trip hop"),
      new(name: "Pop"),
      new(name: "Industrial"),
    ];

    Album[] albums =
    [
      new(
        title: "In the nightside eclipse",
        releaseDate: DateTime.Today,
        artist: artists[0],
        genres: [genres[0]]
      ),
      new(title: "Dummy", releaseDate: DateTime.Today, artist: artists[1], genres: [genres[1]]),
      new(
        title: "Imaginal Disk",
        releaseDate: DateTime.Today,
        artist: artists[2],
        genres: [genres[2]]
      ),
      new(title: "Caligula", releaseDate: DateTime.Today, artist: artists[3], genres: [genres[3]]),
    ];

    foreach(Artist artist in artists)
    {
      context.Add<Artist>(artist);
    }
    foreach(Genre genre in genres)
    {
      context.Add<Genre>(genre);
    }
    foreach(Album album in albums)
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
