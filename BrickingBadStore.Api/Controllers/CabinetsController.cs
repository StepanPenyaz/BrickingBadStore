using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrickingBadStore.Api.Data;
using BrickingBadStore.Api.DTOs;
using BrickingBadStore.Api.Models;

namespace BrickingBadStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CabinetsController : ControllerBase
{
    private readonly StoreDbContext _context;

    public CabinetsController(StoreDbContext context)
    {
        _context = context;
    }

    // GET: api/Cabinets
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CabinetDto>>> GetCabinets()
    {
        var cabinets = await _context.Cabinets
            .Select(c => new CabinetDto
            {
                Id = c.Id,
                Name = c.Name,
                StoreId = c.StoreId
            })
            .ToListAsync();

        return Ok(cabinets);
    }

    // GET: api/Cabinets/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CabinetDto>> GetCabinet(int id)
    {
        var cabinet = await _context.Cabinets.FindAsync(id);

        if (cabinet == null)
        {
            return NotFound();
        }

        var cabinetDto = new CabinetDto
        {
            Id = cabinet.Id,
            Name = cabinet.Name,
            StoreId = cabinet.StoreId
        };

        return Ok(cabinetDto);
    }

    // POST: api/Cabinets
    [HttpPost]
    public async Task<ActionResult<CabinetDto>> CreateCabinet(CreateCabinetDto createDto)
    {
        var cabinet = new Cabinet
        {
            Name = createDto.Name,
            StoreId = createDto.StoreId
        };

        _context.Cabinets.Add(cabinet);
        await _context.SaveChangesAsync();

        var cabinetDto = new CabinetDto
        {
            Id = cabinet.Id,
            Name = cabinet.Name,
            StoreId = cabinet.StoreId
        };

        return CreatedAtAction(nameof(GetCabinet), new { id = cabinet.Id }, cabinetDto);
    }

    // PUT: api/Cabinets/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCabinet(int id, UpdateCabinetDto updateDto)
    {
        var cabinet = await _context.Cabinets.FindAsync(id);

        if (cabinet == null)
        {
            return NotFound();
        }

        cabinet.Name = updateDto.Name;
        cabinet.StoreId = updateDto.StoreId;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await CabinetExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Cabinets/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCabinet(int id)
    {
        var cabinet = await _context.Cabinets.FindAsync(id);

        if (cabinet == null)
        {
            return NotFound();
        }

        _context.Cabinets.Remove(cabinet);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private async Task<bool> CabinetExists(int id)
    {
        return await _context.Cabinets.AnyAsync(e => e.Id == id);
    }
}
