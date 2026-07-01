using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using RymCloneApi.src.Domain;
using System.Net;

namespace RymCloneApi.src.Exceptions.Handlers
{
  public class JsonPatchExceptionHandler : IExceptionHandler
  {
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
      if (exception is not JsonPatchException) return false;

      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
      var test = typeof(Exception);
      await context.Response.WriteAsync(
        new ProblemDetails()
        {
          Description = exception.Message,
          Title = "Invalid request object"
        }.ToString());

      return true;
    }
  }
}
