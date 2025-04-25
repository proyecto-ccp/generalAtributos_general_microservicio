using Atributos.Aplicacion.Dto.Zonas;

namespace Atributos.Aplicacion.Consultas.Zonas
{
    public interface IConsultasZonas
    {
        public Task<ZonaOutList> ObtenerZonas();
        public Task<ZonaOut> ObtenerZonaPorId(Guid id);
        public Task<ZonaOutList> ObtenerZonasPorCiudad(Guid idCiudad);
    }
}
