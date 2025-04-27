
using Atributos.Aplicacion.Dto.AtributosProducto;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Servicios.AtributosProducto;
using AutoMapper;
using MediatR;
using System.Net;

namespace Atributos.Aplicacion.Consultas.AtributosProducto
{
    public class MedidaConsultaHandler : IRequestHandler<MedidaConsulta, ListaMedidasOut>
    {
        private readonly ConsultarAtributos _servicioAtributos;
        private readonly IMapper _mapper;

        public MedidaConsultaHandler(ConsultarAtributos servicioAtributos, IMapper mapper)
        {
            _servicioAtributos = servicioAtributos;
            _mapper = mapper;
        }

        public async Task<ListaMedidasOut> Handle(MedidaConsulta request, CancellationToken cancellationToken)
        {
            ListaMedidasOut output = new()
            {
                Medidas = []
            };

            try
            {
                var medidas = await _servicioAtributos.DarMedidas() ?? [];

                if (medidas.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "El atributo medidas no tiene valores";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    medidas.ForEach(medida => output.Medidas.Add(_mapper.Map<MedidaDto>(medida)));
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Consulta exitosa";
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
