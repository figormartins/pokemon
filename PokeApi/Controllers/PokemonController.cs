using System.Collections.Generic;
using System.Linq;
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
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonController(IPokemonRepository pokemonRepository)
    {
      _pokemonRepository = pokemonRepository;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<PokemonSerialize>>> GetAll()
    {
      var pokemons = await _pokemonRepository.GetPokemonsAsync();

      foreach (var poke in pokemons)
      {
        poke.Image = RetrieveRawUrlImage(poke.Number);
      }

      var pokes = pokemons
        .Select(p => new PokemonSerialize(p));

      return Ok(pokes);
    }

    [HttpGet]
    [Route("{number:int}")]
    public async Task<ActionResult<PokemonSerialize>> GetByNumber(int number)
    {
      var pokemon = await _pokemonRepository.GetPokemonByNumberAsync(number);
      if (pokemon is null)
      {
        return BadRequest("Try a number between 1 and 151");
      }

      pokemon.Image = RetrieveRawUrlImage(pokemon.Number);

      var poke = new PokemonSerialize(pokemon);

      return Ok(poke);
    }

    private string RetrieveRawUrlImage(int number)
    {
      return $"{Request.Scheme}://{Request.Host.Value}/image/{number}";
    }
  }
}