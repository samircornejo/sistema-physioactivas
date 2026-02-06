namespace Fisioterapia.Api.Models;

public class Servicio
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty; // Ej: Masaje Descontracturante
    public string Descripcion { get; set; } = string.Empty; 
    public decimal PrecioPorHora { get; set; } // Ej: 80.00
    public decimal PrecioMediaHora { get; set; } // Ej: 50.00
    public bool Activo { get; set; } = true; // Para ocultarlo si ya no se ofrece
}