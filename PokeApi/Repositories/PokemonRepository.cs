using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokeApi.Data;
using PokeApi.Model;

namespace PokeApi.Repositories
{
  public class PokemonRepository : BaseRepository<Pokemon>, IPokemonRepository
  {
    public PokemonRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task AddPokemons(List<Pokemon> pokemons)
    {
      foreach (var poke in pokemons)
      {
        if (!dbSet.Where(p => p.Number == poke.Number).Any())
        {
          dbSet.Add(poke);
        }
      }

      await context.SaveChangesAsync();
    }

    public async Task<List<Pokemon>> GetPokemons()
    {
      return await dbSet
        .OrderBy(p => p.Number)
        .ToListAsync();
    }
  }
}