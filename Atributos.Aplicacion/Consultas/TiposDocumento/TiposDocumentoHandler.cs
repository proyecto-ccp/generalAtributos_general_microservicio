
using Atributos.Aplicacion.Dto.TiposDocumento;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Servicios.TiposDocumento;
using AutoMapper;
using MediatR;
using System.Net;


namespace Atributos.Aplicacion.Consultas.TiposDocumento
{
    public class TiposDocumentoHandler : IRequestHandler<TiposDocumentoConsulta, TipoDocumentoOutList>
    {
        private readonly IMapper _mapper;
        private readonly ListadoTiposDocumento _listarDocumentos;

        public TiposDocumentoHandler(ListadoTiposDocumento listarDocumentos, IMapper mapper) 
        {
            _listarDocumentos = listarDocumentos;
            _mapper = mapper;
        }

        public async Task<TipoDocumentoOutList> Handle(TiposDocumentoConsulta request, CancellationToken cancellationToken)
        {
            TipoDocumentoOutList output = new()
            {
                TiposDocumentos = []
            };

            try
            {
                var tiposDocumento = await _listarDocumentos.ObtenerTiposDocumento() ?? [];

                if (tiposDocumento.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "Tipos de documento no tiene valores";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    tiposDocumento.ForEach(documento => output.TiposDocumentos.Add(_mapper.Map<TipoDocumentoDto>(documento)));
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
