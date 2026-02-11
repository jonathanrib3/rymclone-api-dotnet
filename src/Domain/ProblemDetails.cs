using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace RymCloneApi.src.Domain
{
  public class ProblemDetails
  {
    public required string Title { get; set; }
    public required string Description { get; set; }

    public override string ToString()
    {
      return JsonSerializer.Serialize(this);
    }
  }
}
