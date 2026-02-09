using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Persistence.Context.Interfaces;
using RymCloneApi.src.Providers;

namespace RymCloneApi.src.Persistence.Context;

public class AppDbContext : DbContext, IAppDbContext
{
  private readonly string _dbUser;
  private readonly string _dbHost;
  private readonly string _dbPassword;
  private readonly string _dbDatabase;
  public DbSet<Genre> Genres { get; set; }
  public DbSet<Artist> Artists { get; set; }
  public DbSet<Album> Albums { get; set; }

  public AppDbContext(DbContextOptions options)
    : base(options)
  {
    _dbUser = EnvProvider.Instance.GetStringValue("DB_USERNAME");
    _dbHost = EnvProvider.Instance.GetStringValue("DB_HOST");
    _dbPassword = EnvProvider.Instance.GetStringValue("DB_PASSWORD");
    _dbDatabase = EnvProvider.Instance.GetStringValue("DB_DATABASE");
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseNpgsql(GetDbConectionString());
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    base.OnModelCreating(modelBuilder);
  }

  private string GetDbConectionString() =>
    $"Host={_dbHost};Username={_dbUser};Password={_dbPassword};Database={_dbDatabase}";
}
