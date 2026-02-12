using System.Net;

namespace RymCloneApi.src.Exceptions.NotFoundErrorException
{
  public class NotFoundException : HttpException
  {
    public NotFoundException(string message) : base(message)
    {
      StatusCode = (int)HttpStatusCode.NotFound;
    }
  }
}
