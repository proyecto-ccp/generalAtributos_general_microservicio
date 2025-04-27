
using Atributos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Atributos.Infraestructura.Configuraciones
{
    [ExcludeFromCodeCoverage]
    public class LocalizacionZonaConfiguracion : IEntityTypeConfiguration<LocalizacionZona>
    {
        public void Configure(EntityTypeBuilder<LocalizacionZona> builder)
        {
            builder.ToView("vw_datosubicacionzona");
            builder.HasNoKey();
            builder.Property(c => c.Idpais).HasColumnName("idpais");
            builder.Property(c => c.NombrePais).HasColumnName("nombrepais");
            builder.Property(c => c.Ididioma).HasColumnName("ididioma");
            builder.Property(c => c.NombreIdioma).HasColumnName("idioma");
            builder.Property(c => c.Idmoneda).HasColumnName("idmoneda");
            builder.Property(c => c.Moneda).HasColumnName("moneda");
            builder.Property(c => c.AcronimoMoneda).HasColumnName("acronimomoneda");
            builder.Property(c => c.Idregion).HasColumnName("idregion");
            builder.Property(c => c.Region).HasColumnName("region");
            builder.Property(c => c.Idciudad).HasColumnName("idciudad");
            builder.Property(c => c.Ciudad).HasColumnName("ciudad");
            builder.Property(c => c.Idzona).HasColumnName("idzona");
            builder.Property(c => c.Zona).HasColumnName("zona");
        }
    }
}
