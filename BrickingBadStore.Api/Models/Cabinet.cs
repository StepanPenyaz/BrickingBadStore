namespace BrickingBadStore.Api.Models;

public class Cabinet
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int StoreId { get; set; }
    public Store Store { get; set; } = null!;
    public List<Group> Groups { get; set; } = new();
}
