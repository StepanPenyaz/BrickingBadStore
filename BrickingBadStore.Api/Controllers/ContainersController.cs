using BrickingBadStore.Api.Data;
using BrickingBadStore.Api.DTOs;
using BrickingBadStore.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrickingBadStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContainersController : ControllerBase
{
    private readonly StoreDbContext _context;

    public ContainersController(StoreDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContainerDto>>> GetContainers()
    {
        var containers = await _context.Containers
            .Select(c => new ContainerDto
            {
                Id = c.Id,
                Capacity = c.Capacity,
                GroupId = c.GroupId
            })
            .ToListAsync();

        return Ok(containers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContainerDto>> GetContainer(int id)
    {
        var container = await _context.Containers.FindAsync(id);

        if (container == null)
        {
            return NotFound();
        }

        var dto = new ContainerDto
        {
            Id = container.Id,
            Capacity = container.Capacity,
            GroupId = container.GroupId
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<ContainerDto>> CreateContainer(CreateContainerDto createDto)
    {
        var container = new Container
        {
            Capacity = createDto.Capacity,
            GroupId = createDto.GroupId
        };

        _context.Containers.Add(container);
        await _context.SaveChangesAsync();

        var dto = new ContainerDto
        {
            Id = container.Id,
            Capacity = container.Capacity,
            GroupId = container.GroupId
        };

        return CreatedAtAction(nameof(GetContainer), new { id = container.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContainer(int id, UpdateContainerDto updateDto)
    {
        var container = await _context.Containers.FindAsync(id);

        if (container == null)
        {
            return NotFound();
        }

        container.Capacity = updateDto.Capacity;
        container.GroupId = updateDto.GroupId;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContainer(int id)
    {
        var container = await _context.Containers.FindAsync(id);

        if (container == null)
        {
            return NotFound();
        }

        _context.Containers.Remove(container);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
