
using Atributos.Dominio.Entidades;
using Atributos.Infraestructura.Configuraciones;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Atributos.Infraestructura.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class AtributosDbContext : DbContext
    {
        public AtributosDbContext(DbContextOptions<AtributosDbContext> options) : base(options) { }

        public DbSet<Medida> Medidas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Color> Colores { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<TipoDocumento> TiposDocumentos { get; set; }
        public DbSet<Localizacion> Localizaciones { get; set; }
        public DbSet<LocalizacionZona> LocalizacionZonas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaConfiguracion());
            modelBuilder.ApplyConfiguration(new ColorConfiguracion());
            modelBuilder.ApplyConfiguration(new MarcaConfiguracion());
            modelBuilder.ApplyConfiguration(new MaterialConfiguracion());
            modelBuilder.ApplyConfiguration(new MedidaConfiguracion());
            modelBuilder.ApplyConfiguration(new ModeloConfiguracion());
            modelBuilder.ApplyConfiguration(new ParametroConfiguracion());
            modelBuilder.ApplyConfiguration(new TipoDocumentoConfiguracion());
            modelBuilder.ApplyConfiguration(new LocalizacionConfiguracion());
            modelBuilder.ApplyConfiguration(new LocalizacionZonaConfiguracion());
        }
    }
}
