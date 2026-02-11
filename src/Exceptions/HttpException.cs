using System.Text.Json;

namespace RymCloneApi.src.Exceptions
{
  public class HttpException : ApplicationException
  {
    public int StatusCode { get; set; }
    public string? Trace { get; set; }
    public Exception? Cause { get; set; }
    public HttpException(int statusCode, string message, string? trace = null, Exception? cause = null)
      : base(message)
    {
      StatusCode = statusCode;
      Trace = trace;
      Cause = cause;
    }
  }
}
