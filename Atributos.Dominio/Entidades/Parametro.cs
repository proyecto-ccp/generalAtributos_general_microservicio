
using System.Diagnostics.CodeAnalysis;

namespace Atributos.Dominio.Entidades
{
    [ExcludeFromCodeCoverage]
    public class Parametro
    {
        public string Id { get; set; }
        public string Valor { get; set; }
        public string Descripcion { get; set; }
    }
}
