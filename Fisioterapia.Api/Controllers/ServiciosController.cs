using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fisioterapia.Api.Data;
using Fisioterapia.Api.Models;
using Microsoft.AspNetCore.Authorization;
namespace Fisioterapia.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiciosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ServiciosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Servicio>>> GetServicios()
    {
        return await _context.Servicios.Where(s => s.Activo).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Servicio>> PostServicio(Servicio servicio)
    {
        _context.Servicios.Add(servicio);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetServicios), new { id = servicio.Id }, servicio);
    }
}