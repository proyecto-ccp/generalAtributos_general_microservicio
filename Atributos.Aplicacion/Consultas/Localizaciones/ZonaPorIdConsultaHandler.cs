
using Atributos.Aplicacion.Dto.Zonas;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Servicios.Localizaciones;
using AutoMapper;
using MediatR;
using System.Net;

namespace Atributos.Aplicacion.Consultas.Localizaciones
{
    public class ZonaPorIdConsultaHandler : IRequestHandler<ZonaPorIdConsulta, ZonaOut>
    {
        private readonly LocalizarZona _servicioZona;
        private readonly IMapper _mapper;

        public ZonaPorIdConsultaHandler(LocalizarZona servicio, IMapper mapper)
        {
            _servicioZona = servicio;
            _mapper = mapper;
        }
        public async Task<ZonaOut> Handle(ZonaPorIdConsulta request, CancellationToken cancellationToken)
        {
            ZonaOut output = new();

            try
            {
                var zona = await _servicioZona.ObtenerZonaPorId(request.Id);

                if (zona is null)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No se encontraron la zona";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    output.Zona = _mapper.Map<ZonaDto>(zona);
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Zona encontrada";
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
