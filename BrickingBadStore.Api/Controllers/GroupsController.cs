using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrickingBadStore.Api.Data;
using BrickingBadStore.Api.DTOs;
using BrickingBadStore.Api.Models;

namespace BrickingBadStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController : ControllerBase
{
    private readonly StoreDbContext _context;

    public GroupsController(StoreDbContext context)
    {
        _context = context;
    }

    // GET: api/Groups
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroups()
    {
        var groups = await _context.Groups
            .Select(g => new GroupDto
            {
                Id = g.Id,
                Name = g.Name,
                CabinetId = g.CabinetId
            })
            .ToListAsync();

        return Ok(groups);
    }

    // GET: api/Groups/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GroupDto>> GetGroup(int id)
    {
        var group = await _context.Groups.FindAsync(id);

        if (group == null)
        {
            return NotFound();
        }

        var groupDto = new GroupDto
        {
            Id = group.Id,
            Name = group.Name,
            CabinetId = group.CabinetId
        };

        return Ok(groupDto);
    }

    // POST: api/Groups
    [HttpPost]
    public async Task<ActionResult<GroupDto>> CreateGroup(CreateGroupDto createDto)
    {
        var group = new Group
        {
            Name = createDto.Name,
            CabinetId = createDto.CabinetId
        };

        _context.Groups.Add(group);
        await _context.SaveChangesAsync();

        var groupDto = new GroupDto
        {
            Id = group.Id,
            Name = group.Name,
            CabinetId = group.CabinetId
        };

        return CreatedAtAction(nameof(GetGroup), new { id = group.Id }, groupDto);
    }

    // PUT: api/Groups/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGroup(int id, UpdateGroupDto updateDto)
    {
        var group = await _context.Groups.FindAsync(id);

        if (group == null)
        {
            return NotFound();
        }

        group.Name = updateDto.Name;
        group.CabinetId = updateDto.CabinetId;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await GroupExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Groups/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGroup(int id)
    {
        var group = await _context.Groups.FindAsync(id);

        if (group == null)
        {
            return NotFound();
        }

        _context.Groups.Remove(group);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private async Task<bool> GroupExists(int id)
    {
        return await _context.Groups.AnyAsync(e => e.Id == id);
    }
}
