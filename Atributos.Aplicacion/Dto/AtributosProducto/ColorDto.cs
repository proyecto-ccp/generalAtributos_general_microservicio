
using System.Diagnostics.CodeAnalysis;

namespace Atributos.Aplicacion.Dto.AtributosProducto
{
    [ExcludeFromCodeCoverage]
    public class ColorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ColorOut : BaseOut
    {
        public ColorDto Color { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ListaColorOut : BaseOut
    {
        public List<ColorDto> Colores { get; set; }
    }
}
