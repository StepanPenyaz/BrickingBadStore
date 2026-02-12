namespace BrickingBadStore.Api.DTOs;

public class StoreDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<CabinetDto> Cabinets { get; set; } = new();
}

public class CabinetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<GroupDto> Groups { get; set; } = new();
}

public class GroupDto
{
    public int Id { get; set; }
    public List<ContainerDto> Containers { get; set; } = new();
}
