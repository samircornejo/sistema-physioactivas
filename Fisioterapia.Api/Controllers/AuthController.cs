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

    // POST: api/auth/registro (Úsalo una vez para crear tu usuario Admin)
    [HttpPost("registro")]
    public async Task<ActionResult<Usuario>> Registrar(UsuarioDto request)
    {
        // Encriptamos la contraseña antes de guardarla
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

    // POST: api/auth/login
    [HttpPost("login")]
    public async Task<ActionResult<object>> Login(LoginDto request)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Username == request.Username);

        // 1. Verificamos si el usuario existe
        if (usuario == null)
        {
            return BadRequest("Usuario no encontrado.");
        }

        // 2. Verificamos si la contraseña coincide con el hash
        if (!BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash))
        {
            return BadRequest("Contraseña incorrecta.");
        }

        // 3. Login exitoso: Devolvemos los datos para armar el Menú Principal
        return Ok(new 
        { 
            mensaje = "Login exitoso", 
            usuario = usuario.NombreCompleto, 
            rol = usuario.Rol,
            // Aquí el frontend decidirá si muestra el menú de "Admin" o "Fisio"
            permisos = new List<string> { "ver_citas", "cobrar", "exportar_excel" } 
        });
    }
}

// Clases auxiliares para recibir los datos (DTOs)
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