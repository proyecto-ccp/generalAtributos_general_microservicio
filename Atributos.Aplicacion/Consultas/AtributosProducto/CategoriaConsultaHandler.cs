
using Atributos.Aplicacion.Dto.AtributosProducto;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Servicios.AtributosProducto;
using AutoMapper;
using MediatR;
using System.Net;

namespace Atributos.Aplicacion.Consultas.AtributosProducto
{
    public class CategoriaConsultaHandler : IRequestHandler<CategoriaConsulta, ListaCategoriaOut>
    {
        private readonly ConsultarAtributos _servicioAtributos;
        private readonly IMapper _mapper;

        public CategoriaConsultaHandler(ConsultarAtributos servicioAtributos, IMapper mapper)
        {
            _servicioAtributos = servicioAtributos;
            _mapper = mapper;
        }

        public async Task<ListaCategoriaOut> Handle(CategoriaConsulta request, CancellationToken cancellationToken)
        {
            ListaCategoriaOut output = new()
            {
                Categorias = []
            };

            try
            {
                var categorias = await _servicioAtributos.DarCategorias() ?? [];

                if (categorias.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "El atributo categorias no tiene valores";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    categorias.ForEach(categoria => output.Categorias.Add(_mapper.Map<CategoriaDto>(categoria)));
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
