using System.Text.Json.Serialization;

namespace PokeApi.Model
{
  public class PokemonWeakness
  {
    public PokemonWeakness(int pokemonId, int typeElementId)
    {
      PokemonId = pokemonId;
      TypeElementId = typeElementId;
    }

    [JsonIgnore]
    public int Id { get; set; }
    [JsonIgnore]
    public int PokemonId { get; set; }
    [JsonIgnore]
    public int TypeElementId { get; set; }
    [JsonIgnore]
    public Pokemon Pokemon { get; set; }
    public TypeElement TypeElement { get; set; }
  }
}