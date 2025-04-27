
using System.Diagnostics.CodeAnalysis;

namespace Atributos.Aplicacion.Dto.AtributosProducto
{
    [ExcludeFromCodeCoverage]
    public class MedidaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class MedidaOut : BaseOut
    {
        public MedidaDto Medida { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ListaMedidasOut : BaseOut
    {
        public List<MedidaDto> Medidas { get; set; }
    }
}
