using Atributos.Aplicacion.Dto.Ciudades;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Servicios.Ciudades;
using AutoMapper;
using System.Net;

namespace Atributos.Aplicacion.Consultas.Ciudades
{
    public class ManejadorConsultas : IConsultasCiudades
    {
        private readonly ObtenerCiudad _obtenerCiudades;
        private readonly ListadoCiudades _listadoCiudades;
        private readonly ListadoCiudadesPorRegion _listadoCiudadesPorRegion;
        private readonly IMapper _mapper;

        public ManejadorConsultas(ObtenerCiudad obtenerCiudades, ListadoCiudades listadoCiudades, ListadoCiudadesPorRegion listadoCiudadesPorRegion, IMapper mapper)
        {
            _obtenerCiudades = obtenerCiudades;
            _listadoCiudades = listadoCiudades;
            _listadoCiudadesPorRegion = listadoCiudadesPorRegion;
            _mapper = mapper;
        }

        public async Task<CiudadOutList> ObtenerCiudades()
        {
            CiudadOutList output = new()
            {
                Ciudades = []
            };

            try
            {
                var Ciudades = await _listadoCiudades.ObtenerCiudades();

                if (Ciudades == null || Ciudades.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No se encontraron Ciudades";
                    output.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Ciudades encontradas";
                    output.Status = HttpStatusCode.OK;
                    output.Ciudades = _mapper.Map<List<CiudadDto>>(Ciudades);
                }
            }
            catch (Exception ex)
            {
                output.Resultado = Resultado.Error;
                output.Mensaje = ex.Message;
                output.Status = HttpStatusCode.InternalServerError;
            }

            return output;
        }

        public async Task<CiudadOut> ObtenerCiudadPorId(Guid id)
        {
            CiudadOut CiudadOut = new();
            try
            {
                var Ciudad = await _obtenerCiudades.ObtenerCiudadPorId(id);

                if (Ciudad == null || Ciudad.Id == Guid.Empty)
                {
                    CiudadOut.Resultado = Resultado.SinRegistros;
                    CiudadOut.Mensaje = "Ciudad NO encontrada";
                    CiudadOut.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    CiudadOut.Resultado = Resultado.Exitoso;
                    CiudadOut.Mensaje = "Ciudad encontrada";
                    CiudadOut.Status = HttpStatusCode.OK;
                    CiudadOut.Ciudad = _mapper.Map<CiudadDto>(Ciudad);
                }
            }
            catch (Exception ex)
            {
                CiudadOut.Resultado = Resultado.Error;
                CiudadOut.Mensaje = ex.Message;
                CiudadOut.Status = HttpStatusCode.InternalServerError;
            }

            return CiudadOut;
        }

        public async Task<CiudadOutList> ObtenerCiudadesPorRegion(int idRegion)
        {
            CiudadOutList output = new()
            {
                Ciudades = []
            };

            try
            {
                var Ciudades = await _listadoCiudadesPorRegion.ObtenerCiudadesPorRegion(idRegion);

                if (Ciudades == null || Ciudades.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No se encontraron Ciudades";
                    output.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Ciudades encontradas";
                    output.Status = HttpStatusCode.OK;
                    output.Ciudades = _mapper.Map<List<CiudadDto>>(Ciudades);
                }
            }
            catch (Exception ex)
            {
                output.Resultado = Resultado.Error;
                output.Mensaje = ex.Message;
                output.Status = HttpStatusCode.InternalServerError;
            }

            return output;
        }
    
    
    }
}
