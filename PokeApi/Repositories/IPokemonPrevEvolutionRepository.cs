using System.Threading.Tasks;

namespace PokeApi.Repositories
{
  public interface IPokemonPrevEvolutionRepository
  {
    Task AddPrevEvolution();
  }
}