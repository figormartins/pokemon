using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokeApi.Model;
using PokeApi.Repositories;

namespace PokeApi.Data
{
  public class DataService : IDataService
  {
    private readonly ApplicationContext context;
    private readonly IPokemonRepository pokemonRepository;
    private readonly ITypeElementRepository typeElementRepository;

    public DataService(ApplicationContext context, IPokemonRepository pokemonRepository, ITypeElementRepository typeElementRepository)
    {
      this.context = context;
      this.pokemonRepository = pokemonRepository;
      this.typeElementRepository = typeElementRepository;
    }

    public async Task InitializeDB()
    {
      context.Database.EnsureCreated();
      List<Pokemon> pokemons = GetPokemons();
      await pokemonRepository.AddPokemons(pokemons);
      await typeElementRepository.AddTypeElements(GetPokemonsSerialized());
    }

    private static List<Pokemon> GetPokemons()
    {
      return GetPokemonsSerialized()
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
    }

    private static List<PokemonSerialize> GetPokemonsSerialized()
    {
      var json = File.ReadAllText("Pokemons.json");
      var pokemons = JsonConvert.DeserializeObject<List<PokemonSerialize>>(json);

      return pokemons;
    }
  }
}