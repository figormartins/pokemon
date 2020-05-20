using System.Linq;
using System.Threading.Tasks;
using PokeApi.Data;
using PokeApi.Model;

namespace PokeApi.Repositories
{
  public class PokemonNextEvolutionRepository : BaseRepository<PokemonNextEvolution>, IPokemonNextEvolutionRepository
  {
    private readonly IPokemonRepository _pokemonRepository;
    public PokemonNextEvolutionRepository(ApplicationContext context, IPokemonRepository pokemonRepository) : base(context)
    {
      _pokemonRepository = pokemonRepository;
    }

    public async Task AddNextEvolution()
    {
      var pokemons = _pokemonRepository.GetPokemons();
      var pokemonsSerialized = _pokemonRepository.GetPokemonsSerialized();

      foreach (var pokeSer in pokemonsSerialized)
      {
        if (pokeSer.NextEvolution != null && pokeSer.NextEvolution.Count > 0)
        {
          var poke = _pokemonRepository.GetPokemonByNumber(pokeSer.Number);

          foreach (var evolution in pokeSer.NextEvolution)
          {
            if (!poke.NextEvolution.Where(x => x.Pokemon.Number == evolution.Number).Any())
            {
              var newPoke = _pokemonRepository.GetPokemonByNumber(evolution.Number);
              var newEvolution = new PokemonNextEvolution(poke.Id, newPoke.Id);
              dbSet.Add(newEvolution);

              context.SaveChanges();
            }
          }
        }
      }

      await context.SaveChangesAsync();
    }
  }
}