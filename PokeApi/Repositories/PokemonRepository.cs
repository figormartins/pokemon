using System.Collections.Generic;
using System.Linq;
using PokeApi.Data;
using PokeApi.Model;

namespace PokeApi.Repositories
{
  public class PokemonRepository : BaseRepository<Pokemon>, IPokemonRepository
  {
    public PokemonRepository(ApplicationContext context) : base(context)
    {
    }

    public void AddPokemons(List<Pokemon> pokemons)
    {
      foreach (var poke in pokemons)
      {
        if (!dbSet.Where(p => p.Number == poke.Number).Any())
        {
            dbSet.Add(poke);
        }
      }

      context.SaveChanges();
    }
  }
}