using Atributos.Dominio.Entidades;

namespace Atributos.Dominio.Puertos.Repositorios
{
    public interface ICiudadRepositorio
    {
        Task<Ciudad> ObtenerCiudadPorId(Guid id);
        Task<List<Ciudad>> ObtenerCiudades();
        Task<List<Ciudad>> ObtenerCiudadesPorRegion(int idRegion);
    }
}
