namespace BrickingBadStore.Api.DTOs;

public class StoreDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<CabinetDto> Cabinets { get; set; } = new();
}
