using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fisioterapia.Api.Data;
using Fisioterapia.Api.Models;
using BCrypt.Net;

namespace Fisioterapia.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("registro")]
    public async Task<ActionResult<Usuario>> Registrar(UsuarioDto request)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var usuario = new Usuario
        {
            Username = request.Username,
            PasswordHash = passwordHash,
            NombreCompleto = request.NombreCompleto,
            Rol = request.Rol
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return Ok("Usuario registrado con éxito");
    }

    [HttpPost("login")]
    public async Task<ActionResult<object>> Login(LoginDto request)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Username == request.Username);

        if (usuario == null)
        {
            return BadRequest("Usuario no encontrado.");
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash))
        {
            return BadRequest("Contraseña incorrecta.");
        }

        return Ok(new 
        { 
            mensaje = "Login exitoso", 
            usuario = usuario.NombreCompleto, 
            rol = usuario.Rol,
            permisos = new List<string> { "ver_citas", "cobrar", "exportar_excel" } 
        });
    }
}

public class UsuarioDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string Rol { get; set; } = "Fisioterapeuta";
}

public class LoginDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}