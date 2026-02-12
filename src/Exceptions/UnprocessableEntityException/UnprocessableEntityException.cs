using System.Net;

namespace RymCloneApi.src.Exceptions.UnprocessableEntityException
{
  public class UnprocessableEntityException : HttpException
  {
    public UnprocessableEntityException(string message) : base(message)
    {
      StatusCode = (int)HttpStatusCode.UnprocessableEntity;
    }
  }
}
