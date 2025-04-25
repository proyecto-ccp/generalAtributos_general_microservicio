
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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Ciudad>(entity =>
        //    {
        //        entity.ToTable("tbl_ciudades"); // Si quieres cambiar el nombre de la tabla
        //        entity.HasKey(e => e.Id);   // Definir clave primaria si no se detecta automáticamente
        //                                    // Agrega otras configuraciones si es necesario
        //    });
        //}
    }

}
