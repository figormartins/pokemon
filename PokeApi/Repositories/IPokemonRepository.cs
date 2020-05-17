using System.Collections.Generic;
using PokeApi.Model;

namespace PokeApi.Repositories
{
  public interface IPokemonRepository
  {
    void AddPokemons(List<Pokemon> pokemons);
  }
}