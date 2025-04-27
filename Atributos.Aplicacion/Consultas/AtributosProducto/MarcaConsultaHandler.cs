
using Atributos.Aplicacion.Dto.AtributosProducto;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Servicios.AtributosProducto;
using AutoMapper;
using MediatR;
using System.Net;

namespace Atributos.Aplicacion.Consultas.AtributosProducto
{
    public class MarcaConsultaHandler : IRequestHandler<MarcaConsulta, ListaMarcaOut>
    {
        private readonly ConsultarAtributos _servicioAtributos;
        private readonly IMapper _mapper;

        public MarcaConsultaHandler(ConsultarAtributos servicioAtributos, IMapper mapper)
        {
            _servicioAtributos = servicioAtributos;
            _mapper = mapper;
        }

        public async Task<ListaMarcaOut> Handle(MarcaConsulta request, CancellationToken cancellationToken)
        {
            ListaMarcaOut output = new()
            {
                Marcas = []
            };

            try
            {
                var marcas = await _servicioAtributos.DarMarcas() ?? [];

                if (marcas.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "El atributo marcas no tiene valores";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    marcas.ForEach(marca => output.Marcas.Add(_mapper.Map<MarcaDto>(marca)));
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
