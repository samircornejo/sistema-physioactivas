namespace Fisioterapia.Api.Models;

public class Servicio
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty; 
    public string Descripcion { get; set; } = string.Empty; 
    public decimal PrecioPorHora { get; set; }
    public decimal PrecioMediaHora { get; set; }
    public bool Activo { get; set; } = true;
}