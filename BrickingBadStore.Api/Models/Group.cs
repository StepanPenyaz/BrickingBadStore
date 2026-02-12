namespace BrickingBadStore.Api.Models;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CabinetId { get; set; }
    public Cabinet Cabinet { get; set; } = null!;
    public ICollection<Container> Containers { get; set; } = new List<Container>();
}
