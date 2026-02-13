using Microsoft.AspNetCore.Diagnostics;
using RymCloneApi.src.Domain;
using System.Net;

namespace RymCloneApi.src.Exceptions.NotFoundErrorException
{
  public class NotFoundExceptionHandler : IExceptionHandler
  {

    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
      if (exception is not NotFoundException) return false;

      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.NotFound;
      await context.Response.WriteAsync(
        new ProblemDetails()
        {
          Description = exception.Message,
          Title = exception.GetType().Name
        }.ToString());

      return true;
    }
  }
}