using BrickingBadStore.Api.Data;
using BrickingBadStore.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrickingBadStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly StoreDbContext _context;

    public StoreController(StoreDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<StoreDto>> GetStore()
    {
        var store = await _context.Stores
            .Include(s => s.Cabinets)
                .ThenInclude(c => c.Groups)
                    .ThenInclude(g => g.Containers)
            .FirstOrDefaultAsync();

        if (store == null)
        {
            return NotFound();
        }

        var storeDto = new StoreDto
        {
            Id = store.Id,
            Name = store.Name,
            Cabinets = store.Cabinets.Select(c => new CabinetDto
            {
                Id = c.Id,
                Name = c.Name,
                Groups = c.Groups.Select(g => new GroupDto
                {
                    Id = g.Id,
                    Containers = g.Containers.Select(cn => new ContainerDto
                    {
                        Id = cn.Id,
                        Capacity = cn.Capacity,
                        GroupId = cn.GroupId
                    }).ToList()
                }).ToList()
            }).ToList()
        };

        return Ok(storeDto);
    }
}
