using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrickingBadStore.Api.Data;
using BrickingBadStore.Api.DTOs;

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

    // GET: api/Store
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
            return NotFound("Store not found");
        }

        var storeDto = new StoreDto
        {
            Id = store.Id,
            Name = store.Name,
            Cabinets = store.Cabinets.Select(c => new CabinetDto
            {
                Id = c.Id,
                Name = c.Name,
                StoreId = c.StoreId,
                Groups = c.Groups.Select(g => new GroupDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    CabinetId = g.CabinetId,
                    Containers = g.Containers.Select(cont => new ContainerDto
                    {
                        Id = cont.Id,
                        Capacity = cont.Capacity,
                        GroupId = cont.GroupId
                    }).ToList()
                }).ToList()
            }).ToList()
        };

        return Ok(storeDto);
    }
}
