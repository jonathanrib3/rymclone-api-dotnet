using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain;

namespace RymCloneApi.src.Context;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions options)
    : base(options) { }

  public DbSet<Genre> Genres { get; set; }
}
