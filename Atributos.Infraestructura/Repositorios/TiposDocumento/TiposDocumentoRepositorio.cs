using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;
using Atributos.Infraestructura.RepositorioGenerico;

namespace Atributos.Infraestructura.Repositorios.TiposDocumento
{
    public class TiposDocumentoRepositorio: ITipoDocumentoRepositorio
    {
        private readonly IRepositorioBaseTiposDocumento<TipoDocumento> _repositorioBase;
        public TiposDocumentoRepositorio(IRepositorioBaseTiposDocumento<TipoDocumento> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }
        
        public async Task<TipoDocumento> Crear(TipoDocumento entity)
        {
            return await _repositorioBase.Crear(entity);
        }
        public async Task<TipoDocumento> BuscarPorLlave(object ValueKey)
        {
            return await _repositorioBase.BuscarPorLlave(ValueKey);
        }
        public async Task<List<TipoDocumento>> DarListado()
        {
            return await _repositorioBase.DarListado();
        }
    
    }
}
