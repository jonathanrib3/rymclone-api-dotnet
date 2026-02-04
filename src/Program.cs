using dotenv.net;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
  app.MapScalarApiReference();
}
app.UseHttpsRedirection();

app.MapGet("/healthcheck", () => new { Message = "everything ok" }).WithDisplayName("Healthcheck");

app.MapControllers();
DotEnv.AutoConfig();
app.Run();
