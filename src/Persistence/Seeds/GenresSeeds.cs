using System;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Persistence.Context;
using RymCloneApi.src.Persistence.Seeds.Interfaces;

namespace RymCloneApi.src.Persistence.Seeds;

public class GenresSeeds : ISeed
{
  public static void Run(AppDbContext context)
  {
    Genre[] genres = new Genre[]
    {
      new Genre(name: "Black metal"),
    };
    context.Genres.Add()
  }
}
