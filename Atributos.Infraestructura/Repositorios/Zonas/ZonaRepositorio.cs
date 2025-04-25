using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;
using Atributos.Infraestructura.RepositorioGenerico;

namespace Atributos.Infraestructura.Repositorios.Zonas
{
    public class ZonaRepositorio : IZonaRepositorio
    {
        private readonly IRepositorioBaseZonas<Zona> _repositorioBase;
        public ZonaRepositorio(IRepositorioBaseZonas<Zona> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        public async Task<Zona> ObtenerZonaPorId(Guid id)
        {
            return await _repositorioBase.BuscarPorLlave(id); 
        }

        public async Task<List<Zona>> ObtenerZonas()
        {
            return await _repositorioBase.DarListado();
        }

        public async Task<List<Zona>> ObtenerZonasPorCiudad(Guid idCiudad)
        {
            return await _repositorioBase.BuscarPorAtributo(idCiudad, "IdCiudad");
        }
    }
}
