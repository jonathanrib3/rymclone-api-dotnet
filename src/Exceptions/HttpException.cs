using System.Text.Json;

namespace RymCloneApi.src.Exceptions
{
  public class HttpException : ApplicationException
  {
    public int StatusCode { get; set; }
    public string? Trace { get; set; }
    public Exception? Cause { get; set; }
    public HttpException(string message) : base(message)
    {
    }
  }
}
