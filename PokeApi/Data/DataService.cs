using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PokeApi.Model;
using PokeApi.Repositories;

namespace PokeApi.Data
{
  public class DataService : IDataService
  {
    private readonly ApplicationContext context;
    private readonly IPokemonRepository pokemonRepository;

    public DataService(ApplicationContext context, IPokemonRepository pokemonRepository)
    {
      this.context = context;
      this.pokemonRepository = pokemonRepository;
    }

    public void InitializeDB()
    {
      context.Database.EnsureCreated();
      List<Pokemon> pokemons = GetPokemons();
      pokemonRepository.AddPokemons(pokemons);
    }

    private static List<Pokemon> GetPokemons()
    {
      var json = File.ReadAllText("Pokemons.json");
      var pokemons = JsonConvert.DeserializeObject<List<PokemonSerialize>>(json)
        .Select(p =>
          new Pokemon(
            p.Number,
            p.Name,
            p.Image,
            p.Height,
            p.Weight,
            p.Candy,
            p.CandyCount,
            p.Egg,
            p.SpawnChance,
            p.AvgSpawns,
            p.SpawnTime
          )
        )
        .ToList();

      return pokemons;
    }
  }
}