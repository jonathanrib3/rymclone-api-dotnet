using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Persistence.Context;

namespace RymCloneApi.src.Persistence.Seeds.Interfaces;

public interface ISeed
{
  public static abstract void Run(DbContext context);
}
