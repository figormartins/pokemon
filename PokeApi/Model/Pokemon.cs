using System.Collections.Generic;

namespace PokeApi.Model
{
  public class Pokemon
  {
    public Pokemon()
    {
      Type = new List<PokemonTypeElement>();
      Weaknesses = new List<PokemonWeakness>();
      NextEvolution = new List<PokemonNextEvolution>();
      PrevEvolution = new List<PokemonPrevEvolution>();
    }

    public Pokemon(int number, string name, string image, double height, double weight, string candy, int candyCount, string egg, double spawnChance, double avgSpawns, string spawnTime) : this()
    {
      Number = number;
      Name = name;
      Image = image;
      Height = height;
      Weight = weight;
      Candy = candy;
      CandyCount = candyCount;
      Egg = egg;
      SpawnChance = spawnChance;
      AvgSpawns = avgSpawns;
      SpawnTime = spawnTime;
    }

    public int Id { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public IList<PokemonTypeElement> Type { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public string Candy { get; set; }
    public int CandyCount { get; set; }
    public string Egg { get; set; }
    public double SpawnChance { get; set; }
    public double AvgSpawns { get; set; }
    public string SpawnTime { get; set; }
    public IList<PokemonWeakness> Weaknesses { get; set; }
    public IList<PokemonNextEvolution> NextEvolution { get; set; }
    public IList<PokemonPrevEvolution> PrevEvolution { get; set; }
  }

  public class Evolution
  {
    public int Number { get; set; }
    public string Name { get; set; }
  }

  public class PokemonSerialize
  {
    public int Id { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public IList<string> Type { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public string Candy { get; set; }
    public int CandyCount { get; set; }
    public string Egg { get; set; }
    public double SpawnChance { get; set; }
    public double AvgSpawns { get; set; }
    public string SpawnTime { get; set; }
    public IList<string> Weaknesses { get; set; }
    public IList<Evolution> NextEvolution { get; set; }
    public IList<Evolution> PrevEvolution { get; set; }
  }
}