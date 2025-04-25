
using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;

namespace Atributos.Dominio.Servicios.Zonas
{
    public class ListadoZonas(IZonaRepositorio _zonarepositorio)
    {
        private readonly IZonaRepositorio zonarepositorio = _zonarepositorio;
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
