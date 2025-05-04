
using Atributos.Aplicacion.Dto.Pais;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Servicios.Localizaciones;
using AutoMapper;
using MediatR;
using System.Net;

namespace Atributos.Aplicacion.Consultas.Localizaciones
{
    class PaisPorIdConsultaHandler : IRequestHandler<PaisPorIdConsulta, PaisOut>
    {
        private readonly LocalizarPais _servicioPais;
        private readonly IMapper _mapper;

        public PaisPorIdConsultaHandler(LocalizarPais servicio, IMapper mapper)
        {
            _servicioPais = servicio;
            _mapper = mapper;
        }
        public async Task<PaisOut> Handle(PaisPorIdConsulta request, CancellationToken cancellationToken)
        {
            PaisOut output = new();

            try
            {
                var pais = await _servicioPais.ObtenerPaisPorId(request.Id);

                if (pais is null)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No se encontro el Pais";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    output.Pais = _mapper.Map<PaisDto>(pais);
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Pais encontrado";
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
