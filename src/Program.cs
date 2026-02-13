using dotenv.net;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Domain;
using RymCloneApi.src.Exceptions.InternalServerErrorException;
using RymCloneApi.src.Exceptions.NotFoundErrorException;
using RymCloneApi.src.Exceptions.UnprocessableEntityException;
using RymCloneApi.src.Persistence;
using RymCloneApi.src.Persistence.Context;
using RymCloneApi.src.Persistence.Context.Interfaces;
using RymCloneApi.src.Persistence.Repositories;
using RymCloneApi.src.Persistence.Repositories.Genres;
using RymCloneApi.src.Persistence.UnitOfWork;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

DotEnv.AutoConfig();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<UnprocessableEntityExceptionHandler>();
builder.Services.AddExceptionHandler<InternalServerErrorExceptionHandler>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
  options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
  options.JsonSerializerOptions.IncludeFields = true;
});

builder.Services.AddScoped<AppDbContextInitializer>();
builder.Services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepository<Genre>,  GenresRepository>();

var app = builder.Build();

app.UseExceptionHandler("/Error");

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
