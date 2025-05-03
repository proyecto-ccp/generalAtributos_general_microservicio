
using System.Diagnostics.CodeAnalysis;

namespace Atributos.Dominio.Entidades
{
    [ExcludeFromCodeCoverage]
    public class LocalizacionZona : LocalizacionBase
    {
        public Guid Idzona { get; set; }
        public string Zona { get; set; }
    }
}
