using Atributos.Aplicacion.Dto.Zonas;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Entidades;
using Atributos.Dominio.Servicios.Zonas;
using AutoMapper;
using System.Net;

namespace Atributos.Aplicacion.Consultas.Zonas
{
    public class ManejadorConsultas: IConsultasZonas
    {
        private readonly ObtenerZona _obtenerZona;
        private readonly ListadoZonas _listadoZonas;
        private readonly ListadoZonasPorCiudad _listadoZonasPorCiudad;
        private readonly IMapper _mapper;
        public ManejadorConsultas(ObtenerZona obtenerZona, ListadoZonas listadoZonas, ListadoZonasPorCiudad listadoZonasPorCiudad, IMapper mapper)
        {
            _obtenerZona = obtenerZona;
            _listadoZonas = listadoZonas;
            _listadoZonasPorCiudad = listadoZonasPorCiudad;
            _mapper = mapper;
        }

        public async Task<ZonaOut> ObtenerZonaPorId(int id)
        {
            ZonaOut ZonaOut = new();
            try
            {
                var Zona = await _obtenerZona.Ejecutar(id);

                if (Zona == null || Zona.Id == Guid.Empty)
                {
                    ZonaOut.Resultado = Resultado.SinRegistros;
                    ZonaOut.Mensaje = "Zona NO encontrada";
                    ZonaOut.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    ZonaOut.Resultado = Resultado.Exitoso;
                    ZonaOut.Mensaje = "Zona encontrada";
                    ZonaOut.Status = HttpStatusCode.OK;
                    ZonaOut.Zona = _mapper.Map<ZonaDto>(Zona);
                }
            }
            catch (Exception ex)
            {
                ZonaOut.Resultado = Resultado.Error;
                ZonaOut.Mensaje = ex.Message;
                ZonaOut.Status = HttpStatusCode.InternalServerError;
            }

            return ZonaOut;
        }

        public async Task<ZonaOutList> ObtenerZonas()
        {
            ZonaOutList output = new()
            {
                Zonas = []
            };

            try
            {
                var Zonas = await _listadoZonas.Ejecutar();

                if (Zonas == null || Zonas.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No se encontraron Zonas";
                    output.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Zonas encontradas";
                    output.Status = HttpStatusCode.OK;
                    output.Zonas = _mapper.Map<List<ZonaDto>>(Zonas);
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

        public async Task<ZonaOutList> ObtenerZonasPorCiudad(Guid idCiudad)
        {
            ZonaOutList output = new()
            {
                Zonas = []
            };

            try
            {
                var Zonas = await _listadoZonasPorCiudad.Ejecutar(idCiudad);

                if (Zonas == null || Zonas.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No se encontraron Zonas para la ciudad";
                    output.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Zonas encontrados en la ciudad";
                    output.Status = HttpStatusCode.OK;
                    output.Zonas = _mapper.Map<List<ZonaDto>>(Zonas);
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
