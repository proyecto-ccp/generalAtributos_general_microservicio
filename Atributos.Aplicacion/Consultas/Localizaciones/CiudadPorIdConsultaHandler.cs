
using Atributos.Aplicacion.Dto.Ciudades;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Servicios.Localizaciones;
using AutoMapper;
using MediatR;
using System.Net;

namespace Atributos.Aplicacion.Consultas.Localizaciones
{
    public class CiudadPorIdConsultaHandler : IRequestHandler<CiudadPorIdConsulta, CiudadOut>
    {
        private readonly LocalizarCiudad _servicioCiudad;
        private readonly IMapper _mapper;
        public CiudadPorIdConsultaHandler(LocalizarCiudad servicio, IMapper mapper)
        {
            _servicioCiudad = servicio;
            _mapper = mapper;
        }
        public async Task<CiudadOut> Handle(CiudadPorIdConsulta request, CancellationToken cancellationToken)
        {
            CiudadOut output = new();

            try
            {
                var Ciudad = await _servicioCiudad.ObtenerCiudadPorId(request.Id);
                
                if (Ciudad is null)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No se encontraron Ciudad";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    output.Ciudad = _mapper.Map<CiudadDto>(Ciudad);
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Ciudades encontradas";
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
