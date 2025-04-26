
using Atributos.Aplicacion.Dto.AtributosProducto;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Servicios.AtributosProducto;
using AutoMapper;
using MediatR;
using System.Net;

namespace Atributos.Aplicacion.Consultas.AtributosProducto
{
    public class ColorConsultaHandler : IRequestHandler<ColorConsulta, ListaColorOut>
    {
        private readonly ConsultarAtributos _servicioAtributos;
        private readonly IMapper _mapper;

        public ColorConsultaHandler(ConsultarAtributos servicioAtributos, IMapper mapper)
        {
            _servicioAtributos = servicioAtributos;
            _mapper = mapper;
        }

        public async Task<ListaColorOut> Handle(ColorConsulta request, CancellationToken cancellationToken)
        {
            ListaColorOut output = new()
            {
                Colores = []
            };

            try
            {
                var colores = await _servicioAtributos.DarColores() ?? [];

                if (colores.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "El atributo colores no tiene valores";
                    output.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    colores.ForEach(color => output.Colores.Add(_mapper.Map<ColorDto>(color)));
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
