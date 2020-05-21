using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokeApi.Model;
using PokeApi.Repositories;

namespace PokeApi.Controllers
{
  [ApiController]
  [Route("image")]
  public class ImageController : ControllerBase
  {
    private readonly IPokemonRepository _pokemonRepository;

    public ImageController(IPokemonRepository pokemonRepository)
    {
      _pokemonRepository = pokemonRepository;
    }

    [HttpGet]
    [Route("{number:int}")]
    public async Task<ActionResult<Pokemon>> GetById(int number)
    {
        var pokemon = await _pokemonRepository.GetPokemonByNumberAsync(number);
        var path = RawPath(pokemon.Name);

        return PhysicalFile(path, "image/jpeg");
    }

    private string RawPath(string name)
    {
      name = name.Replace(' ', '_');
      var path = $"{Directory.GetCurrentDirectory()}\\static\\{name}.gif";
      return path;
    }
  }
}