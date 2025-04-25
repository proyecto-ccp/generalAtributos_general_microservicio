using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;

namespace Atributos.Dominio.Servicios.Ciudades
{
    public class ObtenerCiudad(ICiudadRepositorio _ciudadRepositorio)
    {
        private readonly ICiudadRepositorio ciudadRepositorio = _ciudadRepositorio;
        public async Task<Ciudad> ObtenerCiudadPorId(Guid id)
        {   
            var ciudad = await ciudadRepositorio.ObtenerCiudadPorId(id);
            
            if (ciudad == null)
            {
                throw new Exception("No se encontró la ciudad con el ID proporcionado.");
            }

            return ciudad;
        }
    }
}
