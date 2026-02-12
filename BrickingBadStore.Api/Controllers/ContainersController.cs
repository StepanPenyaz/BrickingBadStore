using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrickingBadStore.Api.Data;
using BrickingBadStore.Api.DTOs;
using BrickingBadStore.Api.Models;

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

    // GET: api/Containers
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

    // GET: api/Containers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ContainerDto>> GetContainer(int id)
    {
        var container = await _context.Containers.FindAsync(id);

        if (container == null)
        {
            return NotFound();
        }

        var containerDto = new ContainerDto
        {
            Id = container.Id,
            Capacity = container.Capacity,
            GroupId = container.GroupId
        };

        return Ok(containerDto);
    }

    // POST: api/Containers
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

        var containerDto = new ContainerDto
        {
            Id = container.Id,
            Capacity = container.Capacity,
            GroupId = container.GroupId
        };

        return CreatedAtAction(nameof(GetContainer), new { id = container.Id }, containerDto);
    }

    // PUT: api/Containers/5
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

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await ContainerExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Containers/5
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

    private async Task<bool> ContainerExists(int id)
    {
        return await _context.Containers.AnyAsync(e => e.Id == id);
    }
}
