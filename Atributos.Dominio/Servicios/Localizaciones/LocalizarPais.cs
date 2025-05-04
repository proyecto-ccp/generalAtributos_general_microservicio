
using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;

namespace Atributos.Dominio.Servicios.Localizaciones
{
    public class LocalizarPais(ILocalizacionRepositorio repositorioLocalizacion)
    {
        private readonly ILocalizacionRepositorio _repositorioLocalizacion = repositorioLocalizacion;

        public async Task<Pais> ObtenerPaisPorId(int id)
        {
            return await _repositorioLocalizacion.ObtenerPaisPorId(id);
        }
        public async Task<List<Pais>> ObtenerPaises()
        {
            return await _repositorioLocalizacion.ObtenerPaises() ?? [];
        }
    }
}
