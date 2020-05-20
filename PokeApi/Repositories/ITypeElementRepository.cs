using System.Collections.Generic;
using System.Threading.Tasks;
using PokeApi.Model;

namespace PokeApi.Repositories
{
  public interface ITypeElementRepository
  {
      Task AddTypeElements(List<PokemonSerialize> pokemons);
      List<TypeElement> GetTypes();
  }
}