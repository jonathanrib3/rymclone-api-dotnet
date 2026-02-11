using Microsoft.AspNetCore.Diagnostics;
using RymCloneApi.src.Domain;
using System.Net;

namespace RymCloneApi.src.Exceptions.InternalServerErrorException
{
  public class InternalServerErrorExceptionHandler : IExceptionHandler
  {

    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      await context.Response.WriteAsync(
        new ProblemDetails()
        {
          Description = exception.Message,
          Title = nameof(exception)
        }.ToString());

      return true;
    }
  }
}