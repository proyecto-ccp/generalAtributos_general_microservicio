using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;

namespace Atributos.Dominio.Servicios.Zonas
{
    public class ObtenerZona(IZonarepositorio _zonarepositorio)
    {
        private readonly IZonarepositorio zonarepositorio = _zonarepositorio;
        public async Task<Zona> Ejecutar(int id)
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
