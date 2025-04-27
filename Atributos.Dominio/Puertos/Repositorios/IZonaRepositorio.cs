
using Atributos.Dominio.Entidades;

namespace Atributos.Dominio.Puertos.Repositorios
{
    public interface IZonaRepositorio
    {
        Task<LocalizacionZona> ObtenerZonaPorId(Guid id);
        Task<List<LocalizacionZona>> ObtenerZonas();
        Task<List<LocalizacionZona>> ObtenerZonasPorCiudad(Guid idCiudad);
    }
}
