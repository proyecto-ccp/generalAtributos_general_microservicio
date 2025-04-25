
using Microsoft.EntityFrameworkCore;
using Atributos.Dominio.Entidades;

namespace Atributos.Infraestructura.Repositorios.TiposDocumento
{
    public class TiposDocumentoDBContext: DbContext
    {
        public TiposDocumentoDBContext(DbContextOptions<TiposDocumentoDBContext> options) : base(options)
        {
        }

        public DbSet<TipoDocumento> TiposDocumentos { get; set; }
    }
}
