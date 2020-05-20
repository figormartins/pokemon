using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

    public List<Pokemon> GetPokemons()
    {
      return dbSet
        .OrderBy(p => p.Number)
        .ToList();
    }

    public async Task<List<Pokemon>> GetPokemonsAsync()
    {
      return await dbSet
        .OrderBy(p => p.Number)
        .Include(t => t.Type)
          .ThenInclude(t => t.TypeElement)
        .Include(w => w.Weaknesses)
          .ThenInclude(t => t.TypeElement)
        .ToListAsync();
    }

    public List<PokemonSerialize> GetPokemonsSerialized()
    {
      var json = File.ReadAllText("Pokemons.json");
      var pokemons = JsonConvert.DeserializeObject<List<PokemonSerialize>>(json);

      return pokemons;
    }
  }
}