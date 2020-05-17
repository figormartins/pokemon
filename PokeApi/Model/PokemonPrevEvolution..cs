namespace PokeApi.Model
{
  public class PokemonPrevEvolution
  {
    public int Id { get; set; }
    public int PokemonId { get; set; }
    public int PrevPokemonId { get; set; }
    public Pokemon Pokemon { get; set; }
    public Pokemon PrevPokemon { get; set; }
  }
}