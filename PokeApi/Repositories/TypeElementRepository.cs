using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokeApi.Data;
using PokeApi.Model;

namespace PokeApi.Repositories
{
  public class TypeElementRepository : BaseRepository<TypeElement>, ITypeElementRepository
  {
    public TypeElementRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task AddTypeElements(List<PokemonSerialize> pokemons)
    {
      HashSet<string> types = new HashSet<string>();

      foreach (var poke in pokemons)
      {
        var currTypes = poke.Type;
        if (currTypes != null)
        {
          foreach (var type in currTypes)
          {
            if (!types.Contains(type))
              types.Add(type);
          }
        }

        var currWeaknesses = poke.Weaknesses;
        if (currWeaknesses != null)
        {
          foreach (var type in currWeaknesses)
          {
            if (!types.Contains(type))
              types.Add(type);
          }
        }
      }

      foreach (var type in types)
      {
        if (!dbSet.Where(t => t.Type == type).Any())
        {
          dbSet.Add(new TypeElement(type));
          context.SaveChanges();
        }
      }

      await context.SaveChangesAsync();
    }

    public List<TypeElement> GetTypes()
    {
      return dbSet
        .ToList();
    }
  }
}