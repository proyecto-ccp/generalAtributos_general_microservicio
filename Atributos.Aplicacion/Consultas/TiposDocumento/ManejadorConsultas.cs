using Atributos.Aplicacion.Dto.TiposDocumento;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Servicios.TiposDocumento;
using AutoMapper;
using System.Net;

namespace Atributos.Aplicacion.Consultas.TiposDocumento
{
    public class ManejadorConsultas: IConsultasTiposDocumento
    {
        private readonly ListadoTiposDocumento _listadoTiposDocumento;
        private readonly IMapper _mapper;
        public ManejadorConsultas( ListadoTiposDocumento listadoTiposDocumento, IMapper mapper)
        {
            _listadoTiposDocumento = listadoTiposDocumento;
            _mapper = mapper;
        }
        public async Task<TipoDocumentoOutList> ObtenerTiposDocumento()
        {
            TipoDocumentoOutList output = new()
            {
                TiposDocumentos = []
            };

            try
            {
                var TipoDocumentos = await _listadoTiposDocumento.ObtenerTiposDocumento();

                if (TipoDocumentos == null || TipoDocumentos.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No se encontraron Tipos de Documento";
                    output.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Tipos de Documento encontrados";
                    output.Status = HttpStatusCode.OK;
                    output.TiposDocumentos = _mapper.Map<List<TipoDocumentoDto>>(TipoDocumentos);
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
