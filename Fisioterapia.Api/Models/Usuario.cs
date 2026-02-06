namespace Fisioterapia.Api.Models;

public class Usuario
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty; // Para el login
    public string PasswordHash { get; set; } = string.Empty; // NUNCA guardes la contraseña en texto plano
    public string Rol { get; set; } = "Fisioterapeuta"; // Admin, Recepcion, Fisioterapeuta
}