using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokeApi.Model;
using PokeApi.Repositories;

namespace PokeApi.Controllers
{
  [ApiController]
  [Route("pokemon")]
  public class PokemonController : ControllerBase
  {
    public readonly IPokemonRepository _pokemonRepository;

    public PokemonController(IPokemonRepository pokemonRepository)
    {
      _pokemonRepository = pokemonRepository;
    }

    [HttpGet("")]
    public async Task<ActionResult<List<Pokemon>>> GetAll()
    {
      var pokemons = await _pokemonRepository.GetPokemons();

      foreach (var poke in pokemons)
      {
          poke.Image = $"{Request.Host.Value}/image/{poke.Number}";
      }
      
      return Ok(pokemons);
    }
  }
}