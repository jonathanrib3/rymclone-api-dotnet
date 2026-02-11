using System.Net;

namespace RymCloneApi.src.Exceptions.InternalServerErrorException
{
  public class InternalServerErrorException : HttpException
  {
    public InternalServerErrorException(int statusCode, string message, string? trace = null, Exception? cause = null) : base(statusCode, message, trace, cause)
    {
      StatusCode = (int)HttpStatusCode.InternalServerError;
    }
  }
}
