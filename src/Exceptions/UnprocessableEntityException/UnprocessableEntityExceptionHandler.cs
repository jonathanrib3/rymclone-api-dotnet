using Microsoft.AspNetCore.Diagnostics;
using RymCloneApi.src.Domain;
using System.Net;

namespace RymCloneApi.src.Exceptions.UnprocessableEntityException
{
  public class UnprocessableEntityExceptionHandler : IExceptionHandler
  {

    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
      if (exception is not UnprocessableEntityException) return false;

      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.UnprocessableContent;
      var test = typeof(Exception);
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