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
    private readonly IPokemonTypeElementRepository pokemonTypeElementRepository;
    private readonly IPokemonWeaknessRepository pokemonWeaknessRepository;

    public DataService(ApplicationContext context,
      IPokemonRepository pokemonRepository,
      ITypeElementRepository typeElementRepository,
      IPokemonTypeElementRepository pokemonTypeElementRepository,
      IPokemonWeaknessRepository pokemonWeaknessRepository)
    {
      this.context = context;
      this.pokemonRepository = pokemonRepository;
      this.typeElementRepository = typeElementRepository;
      this.pokemonTypeElementRepository = pokemonTypeElementRepository;
      this.pokemonWeaknessRepository = pokemonWeaknessRepository;
    }

    public async Task InitializeDB()
    {
      context.Database.EnsureCreated();
      List<Pokemon> pokemons = GetPokemons();
      await pokemonRepository.AddPokemons(pokemons);
      await typeElementRepository.AddTypeElements(pokemonRepository.GetPokemonsSerialized());
      await pokemonTypeElementRepository.AddTypeElements();
      await pokemonWeaknessRepository.AddWeakness();
    }

    private List<Pokemon> GetPokemons()
    {
      var pokemons = pokemonRepository.GetPokemonsSerialized();
        return pokemons.Select(p =>
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
  }
}