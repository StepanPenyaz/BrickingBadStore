namespace BrickingBadStore.Api.DTOs;

public class GroupDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CabinetId { get; set; }
    public List<ContainerDto> Containers { get; set; } = new();
}

public class CreateGroupDto
{
    public string Name { get; set; } = string.Empty;
    public int CabinetId { get; set; }
}

public class UpdateGroupDto
{
    public string Name { get; set; } = string.Empty;
    public int CabinetId { get; set; }
}
