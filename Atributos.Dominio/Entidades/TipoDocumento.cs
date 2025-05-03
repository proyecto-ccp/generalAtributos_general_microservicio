
using System.Diagnostics.CodeAnalysis;

namespace Atributos.Dominio.Entidades
{
    [ExcludeFromCodeCoverage]
    public class TipoDocumento 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}
