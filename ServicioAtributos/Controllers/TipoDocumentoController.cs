using Atributos.Aplicacion.Consultas.TiposDocumento;
using Atributos.Aplicacion.Dto.TiposDocumento;
using Microsoft.AspNetCore.Mvc;

namespace ServicioAtributos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class TipoDocumentoController : Controller
    {
        private readonly IConsultasTiposDocumento _consultasTipoDocumentos;

        public TipoDocumentoController(IConsultasTiposDocumento consultasTipoDocumentos)
        {
            _consultasTipoDocumentos = consultasTipoDocumentos;
        }

        [HttpGet]
        [Route("ObtenerTiposDocumentos")]
        [ProducesResponseType(typeof(TipoDocumentoOutList), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ObtenerTipoDocumentoes()
        {
            try
            {
                var resultado = await _consultasTipoDocumentos.ObtenerTiposDocumento();
                if (resultado.Resultado != Atributos.Aplicacion.Enum.Resultado.Error)
                    return Ok(resultado);
                else
                    return Problem(resultado.Mensaje, statusCode: (int)resultado.Status, title: resultado.Resultado.ToString(), type: resultado.Resultado.ToString(), instance: HttpContext.Request.Path);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
