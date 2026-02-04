using Microsoft.AspNetCore.Mvc;

namespace RymCloneApi.src.Controllers
{
  [ApiController]
  [Route("genres")]
  public class GenreController
  {
    [HttpGet]
    [Route("test")]
    public object Test()
    {
      return new { Message = "ok" };
    }
  }
}
