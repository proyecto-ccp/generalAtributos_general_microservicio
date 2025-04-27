
using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;
using Atributos.Infraestructura.RepositorioGenerico;
using System.Diagnostics.CodeAnalysis;

namespace Atributos.Infraestructura.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class ZonaRepositorio : IZonaRepositorio
    {
        private readonly IRepositorioBase<LocalizacionZona> _localizacionZona;

        public ZonaRepositorio(IRepositorioBase<LocalizacionZona> repositorioBase)
        {
            _localizacionZona = repositorioBase;
        }
        public async Task<LocalizacionZona> ObtenerZonaPorId(Guid id)
        {
            return await _localizacionZona.BuscarPorCampos(x => x.Idzona == id);
        }

        public async Task<List<LocalizacionZona>> ObtenerZonas()
        {
            return await _localizacionZona.DarListado();
        }

        public async Task<List<LocalizacionZona>> ObtenerZonasPorCiudad(Guid idCiudad)
        {
            return await _localizacionZona.DarListadoPorCampos(x => x.Idciudad == idCiudad);
        }
    }
}
