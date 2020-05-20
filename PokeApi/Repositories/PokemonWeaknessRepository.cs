using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokeApi.Data;
using PokeApi.Model;

namespace PokeApi.Repositories
{
  public class PokemonWeaknessRepository : BaseRepository<PokemonWeakness>, IPokemonWeaknessRepository
  {
    private readonly IPokemonRepository _pokemonRepository;
    private readonly ITypeElementRepository _typeElementRepository;

    public PokemonWeaknessRepository(ApplicationContext context, IPokemonRepository pokemonRepository, ITypeElementRepository typeElementRepository) : base(context)
    {
      _pokemonRepository = pokemonRepository;
      _typeElementRepository = typeElementRepository;
    }

    public async Task AddWeakness()
    {
      var pokesSerialized = _pokemonRepository.GetPokemonsSerialized();
      var types = _typeElementRepository.GetTypes();
      var pokemons = _pokemonRepository.GetPokemons();

      foreach (var poke in pokemons)
      {

        var pokeSerialized = pokesSerialized
          .Where(p => p.Number == poke.Number)
          .SingleOrDefault();
        
        if (pokeSerialized.Weaknesses != null && pokeSerialized.Weaknesses.Count > 0)
        {
          foreach (var weakness in pokeSerialized.Weaknesses)
          {
            var newWeakness = types
              .Where(t => t.Type == weakness)
              .SingleOrDefault();
            
            var pokeWeaknesses = new PokemonWeakness(poke.Id, newWeakness.Id);
            var newPokemon = context.Set<Pokemon>()
              .Include(w => w.Weaknesses)
              .Where(p => p.Id == poke.Id)
              .SingleOrDefault();
            
            if(!newPokemon.Weaknesses.Where(t => t.TypeElementId == pokeWeaknesses.TypeElementId).Any())
            {
              newPokemon.Weaknesses.Add(pokeWeaknesses);
              context.SaveChanges();
            }
          }
        }
      }
      
      await context.SaveChangesAsync();
    }
  }
}