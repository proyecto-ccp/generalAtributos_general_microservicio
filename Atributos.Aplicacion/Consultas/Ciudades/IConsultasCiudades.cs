using Atributos.Aplicacion.Dto.Ciudades;

namespace Atributos.Aplicacion.Consultas.Ciudades
{
    public interface IConsultasCiudades
    {
        public Task<CiudadOutList> ObtenerCiudades();
        public Task<CiudadOut> ObtenerCiudadPorId(Guid id);
        public Task<CiudadOutList> ObtenerCiudadesPorRegion(int idRegion);
    }
}
