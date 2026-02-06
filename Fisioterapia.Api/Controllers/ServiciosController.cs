using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fisioterapia.Api.Data;
using Fisioterapia.Api.Models;
using Microsoft.AspNetCore.Authorization; // Importante para seguridad

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

    // GET: api/servicios
    // Esto es lo que cargará tu "Menú Principal"
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Servicio>>> GetServicios()
    {
        // Solo devolvemos los servicios que estén activos
        return await _context.Servicios.Where(s => s.Activo).ToListAsync();
    }

    // POST: api/servicios
    // Para que tú (Admin) puedas agregar nuevos masajes al catálogo
    [HttpPost]
    public async Task<ActionResult<Servicio>> PostServicio(Servicio servicio)
    {
        _context.Servicios.Add(servicio);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetServicios), new { id = servicio.Id }, servicio);
    }
}