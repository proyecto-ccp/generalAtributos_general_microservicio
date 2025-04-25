
using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;

namespace Atributos.Dominio.Servicios.Zonas
{
    public class ListadoZonasPorCiudad(IZonarepositorio _zonarepositorio)
    {
        private readonly IZonarepositorio zonarepositorio = _zonarepositorio;
        public async Task<List<Zona>> Ejecutar(Guid idCiudad)
        {
            var zonas = await zonarepositorio.ObtenerZonasPorCiudad(idCiudad);

            if(zonas == null || zonas.Count == 0)
            {
                throw new Exception("No se encontraron zonas para la ciudad especificada.");
            }

            return zonas;
        }
    }
}
