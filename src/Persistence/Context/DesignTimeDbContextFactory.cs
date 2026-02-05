using System;
using System.IO;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RymCloneApi.src.Providers;

namespace RymCloneApi.src.Persistence.Context;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
  public AppDbContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
    optionsBuilder.UseNpgsql(GetConnectionString());

    return new AppDbContext(optionsBuilder.Options);
  }

  private static string GetConnectionString()
  {
    DotEnv.AutoConfig();
    string dbUser = EnvProvider.Instance.GetStringValue("DB_USERNAME");
    string dbHost = EnvProvider.Instance.GetStringValue("DB_HOST");
    string dbPassword = EnvProvider.Instance.GetStringValue("DB_PASSWORD");
    string dbDatabase = EnvProvider.Instance.GetStringValue("DB_DATABASE");

    return $"Host={dbHost};Username={dbUser};Password={dbPassword};Database={dbDatabase}";
  }
}
