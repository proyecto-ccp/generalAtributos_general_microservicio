
using Atributos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Atributos.Infraestructura.Repositorios.Ciudades
{
    public class CiudadesDBContext: DbContext
    {
        public CiudadesDBContext(DbContextOptions<CiudadesDBContext> options) : base(options)
        {
        }

        public DbSet<Ciudad> Ciudades { get; set; }
    }
}
