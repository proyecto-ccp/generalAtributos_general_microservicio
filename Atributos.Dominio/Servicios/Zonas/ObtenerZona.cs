using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;
using Atributos.Dominio.Servicios.Ciudades;

namespace Atributos.Dominio.Servicios.Zonas
{
    public class ObtenerZona(IZonaRepositorio _zonarepositorio)
    {
        private readonly IZonaRepositorio zonarepositorio = _zonarepositorio;
        public async Task<Zona> Ejecutar(Guid id)
        {
            var zona = await zonarepositorio.ObtenerZonaPorId(id);

            if (zona == null)
            {
                throw new Exception("No se encontró la zona con el ID especificado.");
            }

            return zona;
        }
    }
}
