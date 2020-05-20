using System.Text.Json.Serialization;

namespace PokeApi.Model
{
  public class PokemonNextEvolution
  {
    public PokemonNextEvolution(int pokemonId, int nextPokemonId)
    {
      PokemonId = pokemonId;
      NextPokemonId = nextPokemonId;
    }

    public int Id { get; set; }
    public int PokemonId { get; set; }
    public int NextPokemonId { get; set; }
    [JsonIgnore]
    public Pokemon Pokemon { get; set; }
    [JsonIgnore]
    public Pokemon NextPokemon { get; set; }
  }
}