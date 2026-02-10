using System.Text.Json;

namespace RymCloneApi.src.Errors
{
  public class HttpError : ApplicationException
  {
    public int StatusCode { get; set; }
    public string Trace { get; set; }
    public Exception? Cause { get; set; }
    public HttpError(int statusCode, string message, string trace, Exception? cause = null)
      : base(message)
    {
      StatusCode = statusCode;
      Trace = trace;
      Cause = cause;
    }

    public override string ToString()
    {
      return JsonSerializer.Serialize(this);
    }
  }
}
