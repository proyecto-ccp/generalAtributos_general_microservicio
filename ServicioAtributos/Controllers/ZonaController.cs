using Atributos.Aplicacion.Consultas.Zonas;
using Atributos.Aplicacion.Dto.Zonas;
using Microsoft.AspNetCore.Mvc;

namespace ServicioAtributos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ZonaController : Controller
    {
        private readonly IConsultasZonas _consultasZonas;

        public ZonaController(IConsultasZonas consultasZonas)
        {
            _consultasZonas = consultasZonas;
        }

        [HttpGet]
        [Route("ObtenerZonas")]
        [ProducesResponseType(typeof(ZonaOutList), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ObtenerZonaes()
        {
            try
            {
                var resultado = await _consultasZonas.ObtenerZonas();
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

        [HttpGet]
        [Route("ObtenerZonasPorCiudad")]
        [ProducesResponseType(typeof(ZonaOutList), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ObtenerZonaesPorRegion(Guid idCiudad)
        {
            try
            {
                var resultado = await _consultasZonas.ObtenerZonasPorCiudad(idCiudad);
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

        [HttpGet]
        [Route("ObtenerZona/{id}")]
        [ProducesResponseType(typeof(ZonaOut), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ObtenerCliente(Guid id)
        {
            try
            {
                var resultado = await _consultasZonas.ObtenerZonaPorId(id);
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
