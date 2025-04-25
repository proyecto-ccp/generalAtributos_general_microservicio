
using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;

namespace Atributos.Dominio.Servicios.Ciudades
{
    public class ListadoCiudadesPorRegion(ICiudadRepositorio _ciudadRepositorio)
    {
        private readonly ICiudadRepositorio ciudadRepositorio = _ciudadRepositorio;
        public async Task<List<Ciudad>> ObtenerCiudadesPorRegion(int idRegion)
        {
            var ciudades = await ciudadRepositorio.ObtenerCiudadesPorRegion(idRegion);

            if (ciudades == null || !ciudades.Any())
            {
                throw new Exception("No se encontraron ciudades en la región especificada.");
            }

            return ciudades;
        }
    }
}
