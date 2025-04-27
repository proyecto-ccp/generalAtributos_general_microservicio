using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;
using Atributos.Infraestructura.RepositorioGenerico;

namespace Atributos.Infraestructura.Repositorios
{
    public class TiposDocumentoRepositorio: ITipoDocumentoRepositorio
    {
        private readonly IRepositorioBase<TipoDocumento> _tipoDocumento;
        
        public TiposDocumentoRepositorio(IRepositorioBase<TipoDocumento> repositorioBase)
        {
            _tipoDocumento = repositorioBase;
        }
        
        public async Task<TipoDocumento> Crear(TipoDocumento entity)
        {
            return await _tipoDocumento.Guardar(entity);
        }
        public async Task<TipoDocumento> BuscarPorLlave(object ValueKey)
        {
            return await _tipoDocumento.BuscarPorLlave(ValueKey);
        }
        public async Task<List<TipoDocumento>> DarListado()
        {
            return await _tipoDocumento.DarListado();
        }
    
    }
}
