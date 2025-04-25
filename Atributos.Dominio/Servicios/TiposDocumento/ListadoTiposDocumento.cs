using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;

namespace Atributos.Dominio.Servicios.TiposDocumento
{
    public class ListadoTiposDocumento(ITipoDocumentoRepositorio _tipoDocumentoRepositorio)
    {
        private readonly ITipoDocumentoRepositorio tipoDocumentoRepositorio = _tipoDocumentoRepositorio;
        public async Task<List<TipoDocumento>> ObtenerTiposDocumento()
        {
            var tiposDocumento = await tipoDocumentoRepositorio.DarListado();

            if (tiposDocumento == null || tiposDocumento.Count == 0)
            {
                throw new Exception("No se encontraron tipos de documento.");
            }

            return tiposDocumento;
        }
    }
}
