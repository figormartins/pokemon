using System.Linq;
using System.Threading.Tasks;
using PokeApi.Data;
using PokeApi.Model;

namespace PokeApi.Repositories
{
  public class PokemonPrevEvolutionRepository : BaseRepository<PokemonPrevEvolution>, IPokemonPrevEvolutionRepository
  {
    private readonly IPokemonRepository _pokemonRepository;
    public PokemonPrevEvolutionRepository(ApplicationContext context, IPokemonRepository pokemonRepository) : base(context)
    {
      _pokemonRepository = pokemonRepository;
    }

    public async Task AddPrevEvolution()
    {
      var pokemonsSerialized = _pokemonRepository.GetPokemonsSerialized();

      foreach (var pokeSer in pokemonsSerialized)
      {
        if (pokeSer.PrevEvolution != null && pokeSer.PrevEvolution.Count > 0)
        {
          var poke = _pokemonRepository.GetPokemonByNumber(pokeSer.Number);

          foreach (var evolution in pokeSer.PrevEvolution)
          {
            if (!poke.PrevEvolution.Where(x => x.PrevPokemon.Number == evolution.Number).Any())
            {
              var newPoke = _pokemonRepository.GetPokemonByNumber(evolution.Number);
              var prevEvolution = new PokemonPrevEvolution(poke.Id, newPoke.Id);
              dbSet.Add(prevEvolution);

              context.SaveChanges();
            }
          }
        }
      }

      await context.SaveChangesAsync();
    }
  }
}