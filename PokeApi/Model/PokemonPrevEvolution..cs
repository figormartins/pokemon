using System.Text.Json.Serialization;

namespace PokeApi.Model
{
  public class PokemonPrevEvolution
  {
    public PokemonPrevEvolution(int pokemonId, int prevPokemonId)
    {
      PokemonId = pokemonId;
      PrevPokemonId = prevPokemonId;
    }

    public int Id { get; set; }
    public int PokemonId { get; set; }
    public int PrevPokemonId { get; set; }
    [JsonIgnore]
    public Pokemon Pokemon { get; set; }
    [JsonIgnore]
    public Pokemon PrevPokemon { get; set; }
  }
}