using System.Diagnostics.CodeAnalysis;

namespace Atributos.Aplicacion.Dto.TiposDocumento
{
    [ExcludeFromCodeCoverage]
    public class TipoDocumentoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TipoDocumentoOut : BaseOut
    {
        public TipoDocumentoDto TipoDocumento { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TipoDocumentoOutList : BaseOut
    {
        public List<TipoDocumentoDto> TiposDocumentos { get; set; }
    }
}