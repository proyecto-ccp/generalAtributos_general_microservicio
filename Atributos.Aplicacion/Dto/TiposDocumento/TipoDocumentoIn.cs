using System.Diagnostics.CodeAnalysis;

namespace Atributos.Aplicacion.Dto.TiposDocumento
{
    [ExcludeFromCodeCoverage]
    public class TipoDocumentoIn
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}
