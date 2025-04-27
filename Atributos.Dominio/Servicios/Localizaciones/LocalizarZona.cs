using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;

namespace Atributos.Dominio.Servicios.Localizaciones
{
    public class LocalizarZona(IZonaRepositorio repositorioLocalizacion)
    {
        private readonly IZonaRepositorio _repositorioLocalizacion = repositorioLocalizacion;

        public async Task<LocalizacionZona> ObtenerZonaPorId(Guid id)
        {
            return await _repositorioLocalizacion.ObtenerZonaPorId(id);
        }

        public async Task<List<LocalizacionZona>> ObtenerZonaPorCiudad(Guid idCiudad)
        {
            return await _repositorioLocalizacion.ObtenerZonasPorCiudad(idCiudad) ?? [];
        }

        public async Task<List<LocalizacionZona>> ObtenerZonas()
        {
            return await _repositorioLocalizacion.ObtenerZonas() ?? [];
        }
    }
}
