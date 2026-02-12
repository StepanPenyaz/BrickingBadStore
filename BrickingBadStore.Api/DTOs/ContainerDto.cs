namespace BrickingBadStore.Api.DTOs;

public class ContainerDto
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public int GroupId { get; set; }
}

public class CreateContainerDto
{
    public int Capacity { get; set; }
    public int GroupId { get; set; }
}

public class UpdateContainerDto
{
    public int Capacity { get; set; }
    public int GroupId { get; set; }
}
