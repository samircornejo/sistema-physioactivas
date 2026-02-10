using System.ComponentModel.DataAnnotations.Schema;

namespace Fisioterapia.Api.Models;

public class Sesion
{
    public int Id { get; set; }
    
    // Relación con el Paciente
    public int PacienteId { get; set; }
    public Paciente? Paciente { get; set; }

    public string ServicioNombre { get; set; } = string.Empty;
    public int DuracionMinutos { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal MontoCobrado { get; set; } 

    public string MetodoPago { get; set; } = string.Empty; 
    public DateTime FechaHoraInicio { get; set; }
    public DateTime FechaHoraFin { get; set; }
    
    public string Estado { get; set; } = "Completado";

}