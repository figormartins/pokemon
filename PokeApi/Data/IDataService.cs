using System.Threading.Tasks;

namespace PokeApi.Data
{
  public interface IDataService
  {
      Task InitializeDB();
  }
}