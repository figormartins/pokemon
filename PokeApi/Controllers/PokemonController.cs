using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokeApi.Model;
using PokeApi.Repositories;
using PokeApi.Services;

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
    public async Task<ActionResult<PagedService<PokemonSerialize>>> GetAll(
      string name = "",
      int page = 1,
      int quantity = 9
    )
    {
      var pokemons = await _pokemonRepository.GetPokemonsByNameAsync(name);

      foreach (var poke in pokemons)
      {
        poke.Image = RetrieveRawUrlImage(poke.Number);
      }

      var pokes = pokemons
        .Select(poke => new PokemonSerialize(poke));

      var pagedPokemons = new PagedService<PokemonSerialize>(pokes, page, quantity);

      return Ok(pagedPokemons);
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