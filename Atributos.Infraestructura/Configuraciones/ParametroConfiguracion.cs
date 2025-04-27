
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Atributos.Dominio.Entidades;
using System.Diagnostics.CodeAnalysis;

namespace Atributos.Infraestructura.Configuraciones
{
    [ExcludeFromCodeCoverage]
    public class ParametroConfiguracion : IEntityTypeConfiguration<Parametro>
    {
        public void Configure(EntityTypeBuilder<Parametro> builder)
        {
            builder.ToTable("tbl_parametros");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Valor)
                .HasColumnName("valor")
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.Descripcion)
                .HasColumnName("descripcion")
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
