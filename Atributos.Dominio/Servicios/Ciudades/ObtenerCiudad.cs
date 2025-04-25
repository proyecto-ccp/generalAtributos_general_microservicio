using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;

namespace Atributos.Dominio.Servicios.Ciudades
{
    public class ObtenerCiudad(ICiudadRepositorio ciudadRepositorio)
    {
        private readonly ICiudadRepositorio _ciudadRepositorio = ciudadRepositorio;
        public async Task<Ciudad> ObtenerCiudadPorId(Guid id)
        {   
            var ciudad = await _ciudadRepositorio.ObtenerCiudadPorId(id);
            
            if (ciudad == null)
            {
                throw new Exception("No se encontró la ciudad con el ID proporcionado.");
            }

            return ciudad;
        }
    }
}
