
using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;

namespace Atributos.Dominio.Servicios.Localizaciones
{
    public class LocalizarCiudad (ILocalizacionRepositorio repositorioLocalizacion)
    {
        private readonly ILocalizacionRepositorio _repositorioLocalizacion = repositorioLocalizacion;

        public async Task<Localizacion> ObtenerCiudadPorId(Guid id)
        {
            return await _repositorioLocalizacion.ObtenerCiudadPorId(id);
        }

        public async Task<List<Localizacion>> ObtenerCiudadPorRegion(int idRegion)
        {
            return await _repositorioLocalizacion.ObtenerCiudadesPorRegion(idRegion) ?? [];
        }

        public async Task<List<Localizacion>> ObtenerCiudades()
        {
            return await _repositorioLocalizacion.ObtenerCiudades() ?? [];
        }
    }
}
