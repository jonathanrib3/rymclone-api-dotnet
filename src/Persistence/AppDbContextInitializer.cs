using RymCloneApi.src.Persistence.Context;
using RymCloneApi.src.Persistence.Seeds;
using System;

namespace RymCloneApi.src.Persistence;

public class AppDbContextInitializer
{
  private readonly AppDbContext _context;
  public AppDbContextInitializer(AppDbContext context)
  {
    this._context = context;
  }

  public async Task Seed()
  {
    if (InitialDevSeeds.ShouldSeed(_context))
    {
      InitialDevSeeds.Run(_context);
      await _context.SaveChangesAsync();
    }

  }
}
