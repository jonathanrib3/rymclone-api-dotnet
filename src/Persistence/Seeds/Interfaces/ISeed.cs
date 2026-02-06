using System;
using RymCloneApi.src.Persistence.Context;

namespace RymCloneApi.src.Persistence.Seeds.Interfaces;

public interface ISeed
{
  public static void Run(AppDbContext context) { }
}
