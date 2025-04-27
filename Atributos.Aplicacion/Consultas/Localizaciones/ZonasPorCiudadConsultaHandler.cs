using Atributos.Aplicacion.Dto.Zonas;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Servicios.Localizaciones;
using AutoMapper;
using MediatR;
using System.Net;

namespace Atributos.Aplicacion.Consultas.Localizaciones
{
    public class ZonasPorCiudadConsultaHandler : IRequestHandler<ZonasPorCiudadConsulta, ZonaOutList>
    {
        private readonly LocalizarZona _servicioZona;
        private readonly IMapper _mapper;

        public ZonasPorCiudadConsultaHandler(LocalizarZona servicio, IMapper mapper)
        {
            _servicioZona = servicio;
            _mapper = mapper;
        }
        public async Task<ZonaOutList> Handle(ZonasPorCiudadConsulta request, CancellationToken cancellationToken)
        {
            ZonaOutList output = new()
            {
                Zonas = []
            };

            try
            {
                var Zonas = await _servicioZona.ObtenerZonaPorCiudad(request.IdCiudad);

                if (Zonas.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No se encontraron Zonas";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    Zonas.ForEach(ciudad => output.Zonas.Add(_mapper.Map<ZonaDto>(ciudad)));
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Zonas encontradas";
                    output.Status = HttpStatusCode.OK;

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
