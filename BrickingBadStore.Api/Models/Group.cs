namespace BrickingBadStore.Api.Models;

public class Group
{
    public int Id { get; set; }
    public int CabinetId { get; set; }
    public Cabinet Cabinet { get; set; } = null!;
    public List<Container> Containers { get; set; } = new();
}
