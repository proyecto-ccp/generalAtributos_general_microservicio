namespace Atributos.Aplicacion.Dto.TiposDocumento
{
    public class TipoDocumentoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }

    public class TipoDocumentoOut : BaseOut
    {
        public TipoDocumentoDto TipoDocumento { get; set; }
    }

    public class TipoDocumentoOutList : BaseOut
    {
        public List<TipoDocumentoDto> TiposDocumentos { get; set; }
    }
}