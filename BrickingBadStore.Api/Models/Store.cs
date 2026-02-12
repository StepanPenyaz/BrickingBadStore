namespace BrickingBadStore.Api.Models;

public class Store
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Cabinet> Cabinets { get; set; } = new();
}
