using dotenv.net;
using Microsoft.EntityFrameworkCore;
using RymCloneApi.src.Context;
using RymCloneApi.src.Providers;
using Scalar.AspNetCore;

DotEnv.AutoConfig();
var builder = WebApplication.CreateBuilder(args);

string dbUser = EnvProvider.Instance.GetStringValue("DB_USERNAME");
string dbHost = EnvProvider.Instance.GetStringValue("DB_HOST");
string dbPassword = EnvProvider.Instance.GetStringValue("DB_PASSWORD");
string dbDatabase = EnvProvider.Instance.GetStringValue("DB_DATABASE");
string dbConnection = $"postgresql://{dbUser}:{dbPassword}@{dbHost}/{dbDatabase}";

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
{
  options.UseNpgsql(dbConnection);
});

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
