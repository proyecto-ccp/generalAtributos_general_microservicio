using Atributos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Atributos.Infraestructura.Repositorios.Zonas
{
    public class ZonasDBContext : DbContext
    {
        public ZonasDBContext(DbContextOptions<ZonasDBContext> options) : base(options)
        {
        }
        public DbSet<Zona> Zonas { get; set; }

    }
}
