
using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;

namespace Atributos.Dominio.Servicios.Zonas
{
    public class ListadoZonas(IZonarepositorio _zonarepositorio)
    {
        private readonly IZonarepositorio zonarepositorio = _zonarepositorio;
        public async Task<List<Zona>> Ejecutar()
        {
            var zonas = await zonarepositorio.ObtenerZonas();

            if(zonas == null || !zonas.Any())
            {
                throw new Exception("No se encontraron zonas.");
            }

            return zonas;
        }
    }
}
