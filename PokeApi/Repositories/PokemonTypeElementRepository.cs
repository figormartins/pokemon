using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokeApi.Data;
using PokeApi.Model;

namespace PokeApi.Repositories
{
  public class PokemonTypeElementRepository : BaseRepository<PokemonTypeElement>, IPokemonTypeElementRepository
  {
    private readonly IPokemonRepository _pokemonRepository;
    private readonly ITypeElementRepository _typeElementRepository;
    public PokemonTypeElementRepository(ApplicationContext context, IPokemonRepository pokemonRepository, ITypeElementRepository typeElementRepository) : base(context)
    {
      _pokemonRepository = pokemonRepository;
      _typeElementRepository = typeElementRepository;
    }

    public async Task AddTypeElements()
    {
      var pokesSerialized = _pokemonRepository.GetPokemonsSerialized();
      var types = _typeElementRepository.GetTypes();
      var pokemons = _pokemonRepository.GetPokemons();

      foreach (var poke in pokemons)
      {

        var pokeSerialized = pokesSerialized
          .Where(p => p.Number == poke.Number)
          .SingleOrDefault();
        
        if (pokeSerialized.Type != null && pokeSerialized.Type.Count > 0)
        {
          foreach (var type in pokeSerialized.Type)
          {
            Console.WriteLine(type);
            var newType = types
              .Where(t => t.Type == type)
              .SingleOrDefault();
            
            var pokeTypeElement = new PokemonTypeElement(poke.Id, newType.Id);
            var newPokemon = context.Set<Pokemon>()
              .Include(t => t.Type)
              .Where(p => p.Id == poke.Id)
              .SingleOrDefault();
            
            if(!newPokemon.Type.Where(t => t.TypeElementId == pokeTypeElement.TypeElementId).Any())
            {
              newPokemon.Type.Add(pokeTypeElement);
              context.SaveChanges();
            }
          }
        }
      }
      
      await context.SaveChangesAsync();
    }
  }
}