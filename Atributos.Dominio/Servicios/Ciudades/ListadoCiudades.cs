
using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;

namespace Atributos.Dominio.Servicios.Ciudades
{
    public class ListadoCiudades(ICiudadRepositorio _ciudadRepositorio)
    {
        private readonly ICiudadRepositorio ciudadRepositorio = _ciudadRepositorio;
        public async Task<List<Ciudad>> ObtenerCiudades()
        {
            var ciudades = await ciudadRepositorio.ObtenerCiudades();

            if (ciudades == null || !ciudades.Any())
            {
                throw new Exception("No se encontraron ciudades.");
            }

            return ciudades;
        }
    }
}
