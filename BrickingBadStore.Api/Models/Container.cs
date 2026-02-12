namespace BrickingBadStore.Api.Models;

public class Container
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; } = null!;
}
