namespace PokeApi.Model
{
  public class PokemonNextEvolution
  {
    public int Id { get; set; }
    public int PokemonId { get; set; }
    public int NextPokemonId { get; set; }
    public Pokemon Pokemon { get; set; }
    public Pokemon NextPokemon { get; set; }
  }
}