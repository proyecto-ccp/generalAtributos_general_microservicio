
using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;
using Atributos.Infraestructura.RepositorioGenerico;
using System.Diagnostics.CodeAnalysis;

namespace Atributos.Infraestructura.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class LocalizacionRepositorio : ILocalizacionRepositorio
    {
        private readonly IRepositorioBase<Localizacion> _localizacion;

        public LocalizacionRepositorio(IRepositorioBase<Localizacion> repositorioBase)
        {
            _localizacion = repositorioBase;
        }
        public async Task<List<Localizacion>> ObtenerCiudades()
        {
            return await _localizacion.DarListado();
        }

        public async Task<List<Localizacion>> ObtenerCiudadesPorRegion(int idRegion)
        {
            return await _localizacion.DarListadoPorCampos(x => x.Idregion == idRegion);
        }

        public async Task<Localizacion> ObtenerCiudadPorId(Guid id)
        {
            return await _localizacion.BuscarPorCampos(x => x.Idciudad == id);
        }
    }
}
