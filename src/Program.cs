using dotenv.net;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Persistence;
using RymCloneApi.src.Persistence.Context;
using RymCloneApi.src.Persistence.Context.Interfaces;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

DotEnv.AutoConfig();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddJsonOptions(options =>
  options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<AppDbContextInitializer>();
builder.Services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
  app.MapScalarApiReference("/api-docs", options =>
  {
    options.WithTheme(ScalarTheme.Laserwave);
    options.ForceDarkMode();
  });

  using (var scope = app.Services.CreateScope())
  {
    var dbInitializer = scope.ServiceProvider.GetRequiredService<AppDbContextInitializer>();

    await dbInitializer.Seed();
  }
}

app.UseHttpsRedirection();

app.MapGet("/healthcheck", () => new { Message = "everything ok" }).WithDisplayName("Healthcheck");
app.MapControllers();

app.Run();
