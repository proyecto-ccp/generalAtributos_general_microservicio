
using System.Diagnostics.CodeAnalysis;

namespace Atributos.Dominio.Entidades
{
    [ExcludeFromCodeCoverage]
    public abstract class AtributoBase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}
