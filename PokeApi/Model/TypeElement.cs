namespace PokeApi.Model
{
  public class TypeElement
  {
    public TypeElement(string type)
    {
      Type = type;
    }

    public int Id { get; set; }
    public string Type { get; set; }
  };
}