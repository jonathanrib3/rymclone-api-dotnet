using System.Net;

namespace RymCloneApi.src.Exceptions.InternalServerErrorException
{
  public class InternalServerErrorException : HttpException
  {
    public InternalServerErrorException(string message) : base(message)
    {
      StatusCode = (int)HttpStatusCode.InternalServerError;
    }
  }
}
