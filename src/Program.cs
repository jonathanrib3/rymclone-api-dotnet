using dotenv.net;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Persistence.Context;
using RymCloneApi.src.Providers;
using Scalar.AspNetCore;

DotEnv.AutoConfig();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
  app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapGet("/healthcheck", () => new { Message = "everything ok" }).WithDisplayName("Healthcheck");
app.MapControllers();

app.Run();
