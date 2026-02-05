using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fisioterapia.Api.Data;
using Fisioterapia.Api.Models;

namespace Fisioterapia.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public PacientesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/pacientes (Listar todos)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
    {
        return await _context.Pacientes.ToListAsync();
    }

    // POST: api/pacientes (Crear uno nuevo)
    [HttpPost]
    public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
    {
        _context.Pacientes.Add(paciente);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPacientes), new { id = paciente.Id }, paciente);
    }
}