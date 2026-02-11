using System.Net;

namespace RymCloneApi.src.Exceptions.NotFoundErrorException
{
  public class NotFoundException : HttpException
  {
    public NotFoundException(int statusCode, string message, string? trace = null, Exception? cause = null) : base(statusCode, message, trace, cause)
    {
      StatusCode = (int)HttpStatusCode.NotFound;
    }
  }
}
