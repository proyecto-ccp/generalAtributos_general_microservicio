
using Atributos.Aplicacion.Dto.Ciudades;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Servicios.Localizaciones;
using AutoMapper;
using MediatR;
using System.Net;

namespace Atributos.Aplicacion.Consultas.Localizaciones
{
    public class CiudadesConsultaHandler : IRequestHandler<CiudadesConsulta, CiudadOutList>
    {
        private readonly LocalizarCiudad _servicioCiudad;
        private readonly IMapper _mapper;

        public CiudadesConsultaHandler(LocalizarCiudad servicio, IMapper mapper)
        {
            _servicioCiudad = servicio;
            _mapper = mapper;
        }

        public async Task<CiudadOutList> Handle(CiudadesConsulta request, CancellationToken cancellationToken)
        {
            CiudadOutList output = new()
            {
                Ciudades = []
            };

            try
            {
                var Ciudades = await _servicioCiudad.ObtenerCiudades();

                if (Ciudades.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No se encontraron Ciudades";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    Ciudades.ForEach(ciudad => output.Ciudades.Add(_mapper.Map<CiudadDto>(ciudad)));
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
