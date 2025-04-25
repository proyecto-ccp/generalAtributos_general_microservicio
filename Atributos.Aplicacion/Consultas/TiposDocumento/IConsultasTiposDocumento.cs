using Atributos.Aplicacion.Dto.TiposDocumento;

namespace Atributos.Aplicacion.Consultas.TiposDocumento
{
    public interface IConsultasTiposDocumento
    {
        public Task<TipoDocumentoOutList> ObtenerTiposDocumento();
    }
}
