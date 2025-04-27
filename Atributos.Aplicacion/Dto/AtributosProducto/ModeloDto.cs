
using System.Diagnostics.CodeAnalysis;

namespace Atributos.Aplicacion.Dto.AtributosProducto
{
    [ExcludeFromCodeCoverage]
    public class ModeloDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ModeloOut : BaseOut
    {
        public ModeloDto Modelo { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ListaModelosOut : BaseOut
    {
        public List<ModeloDto> Modelos { get; set; }
    }
}
