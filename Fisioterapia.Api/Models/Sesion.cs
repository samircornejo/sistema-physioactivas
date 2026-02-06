using System.ComponentModel.DataAnnotations.Schema;

namespace Fisioterapia.Api.Models;

public class Sesion
{
    public int Id { get; set; }
    
    // Relación con el Paciente
    public int PacienteId { get; set; }
    public Paciente? Paciente { get; set; }

    // Datos del Servicio realizado (Guardamos copia por si cambian los precios en el futuro)
    public string ServicioNombre { get; set; } = string.Empty;
    public int DuracionMinutos { get; set; } // 30, 45, 60, 90
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal MontoCobrado { get; set; } // El precio final calculado

    public string MetodoPago { get; set; } = string.Empty; // Efectivo, Yape, Tarjeta
    
    public DateTime FechaHoraInicio { get; set; }
    public DateTime FechaHoraFin { get; set; }
    
    public string Estado { get; set; } = "Completado"; // En Curso, Completado, Cancelado
    
    // Aquí iría el ID del trabajador (lo veremos cuando hagamos el Login)
    // public int TrabajadorId { get; set; } 
}