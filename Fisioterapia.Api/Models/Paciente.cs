namespace Fisioterapia.Api.Models;

public class Paciente
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string DNI { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
    public string MotivoConsulta { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
}