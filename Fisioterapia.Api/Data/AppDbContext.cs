using Microsoft.EntityFrameworkCore;
using Fisioterapia.Api.Models;

namespace Fisioterapia.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Esta línea crea la tabla de Pacientes
    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public DbSet<Servicio> Servicios => Set<Servicio>();
    public DbSet<Sesion> Sesiones => Set<Sesion>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
}