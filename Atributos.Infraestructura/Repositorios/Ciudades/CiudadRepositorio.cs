using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;
using Atributos.Infraestructura.RepositorioGenerico;

namespace Atributos.Infraestructura.Repositorios.Ciudades
{
    public class CiudadRepositorio : ICiudadRepositorio
    {
        private readonly IRepositorioBase<Ciudad> _repositorioBase;
        public CiudadRepositorio(IRepositorioBase<Ciudad> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        public async Task<List<Ciudad>> ObtenerCiudades()
        {
            return await _repositorioBase.DarListado();
        }

        public async Task<List<Ciudad>> ObtenerCiudadesPorRegion(int idRegion)
        {
            return await _repositorioBase.BuscarPorAtributo(idRegion, "IdRegion");
        }

        public async Task<Ciudad> ObtenerCiudadPorId(Guid id)
        {
            return await _repositorioBase.BuscarPorLlave(id);
        }
    }
}
