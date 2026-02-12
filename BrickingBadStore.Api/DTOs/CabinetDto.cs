namespace BrickingBadStore.Api.DTOs;

public class CabinetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int StoreId { get; set; }
    public List<GroupDto> Groups { get; set; } = new();
}
