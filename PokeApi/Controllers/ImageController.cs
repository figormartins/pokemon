using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokeApi.Model;

namespace PokeApi.Controllers
{
  [ApiController]
  [Route("image")]
  public class ImageController : ControllerBase
  {
    [HttpGet("{id}")]
    public async Task<ActionResult<Pokemon>> Get(long id)
    {
      var path = System.IO.Directory.GetCurrentDirectory() + "\\static\\Charizard.gif";
      return PhysicalFile(path, "image/jpeg");
    }
  }
}