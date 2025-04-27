
using Atributos.Aplicacion.Dto.Ciudades;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Servicios.Localizaciones;
using AutoMapper;
using MediatR;
using System.Net;

namespace Atributos.Aplicacion.Consultas.Localizaciones
{
    public class CiudadPorRegionConsultaHandler : IRequestHandler<CiudadPorRegionConsulta, CiudadOutList>
    {
        private readonly LocalizarCiudad _servicioCiudad;
        private readonly IMapper _mapper;
        public CiudadPorRegionConsultaHandler(LocalizarCiudad servicio, IMapper mapper)
        {
            _servicioCiudad = servicio;
            _mapper = mapper;
        }
        public async Task<CiudadOutList> Handle(CiudadPorRegionConsulta request, CancellationToken cancellationToken)
        {
            CiudadOutList output = new()
            {
                Ciudades = []
            };
            try
            {
                var Ciudades = await _servicioCiudad.ObtenerCiudadPorRegion(request.IdRegion);
                if (Ciudades.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No se encontro la Ciudad";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    Ciudades.ForEach(ciudad => output.Ciudades.Add(_mapper.Map<CiudadDto>(ciudad)));
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Ciudad encontrada";
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
