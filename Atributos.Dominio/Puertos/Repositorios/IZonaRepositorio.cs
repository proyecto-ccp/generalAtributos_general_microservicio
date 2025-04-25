
using Atributos.Dominio.Entidades;

namespace Atributos.Dominio.Puertos.Repositorios
{
    public interface IZonaRepositorio
    {
        Task<Zona> ObtenerZonaPorId(Guid id);
        Task<List<Zona>> ObtenerZonas();
        Task<List<Zona>> ObtenerZonasPorCiudad(Guid idCiudad);
    }
}
