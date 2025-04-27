

using Atributos.Dominio.Entidades;

namespace Atributos.Dominio.Puertos.Repositorios
{
    public interface ILocalizacionRepositorio
    {
        Task<Localizacion> ObtenerCiudadPorId(Guid id);
        Task<List<Localizacion>> ObtenerCiudades();
        Task<List<Localizacion>> ObtenerCiudadesPorRegion(int idRegion);
    }
}
