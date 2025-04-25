using Atributos.Aplicacion.Consultas.Ciudades;
using Atributos.Aplicacion.Dto.Ciudades;
using Microsoft.AspNetCore.Mvc;

namespace ServicioAtributos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CiudadController : Controller
    {
        private readonly IConsultasCiudades _consultasCiudades;

        public CiudadController(IConsultasCiudades consultasCiudades)
        {
            _consultasCiudades = consultasCiudades;
        }

        [HttpGet]
        [Route("ObtenerCiudades")]
        [ProducesResponseType(typeof(CiudadOutList), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ObtenerCiudades()
        {
            try
            {
                var resultado = await _consultasCiudades.ObtenerCiudades();
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
        [Route("ObtenerCiudadesPorRegion")]
        [ProducesResponseType(typeof(CiudadOutList), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ObtenerCiudadesPorRegion(int idRegion)
        {
            try
            {
                var resultado = await _consultasCiudades.ObtenerCiudadesPorRegion(idRegion);
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
        [Route("ObtenerCiudad/{id}")]
        [ProducesResponseType(typeof(CiudadOut), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ObtenerCliente(Guid id)
        {
            try
            {
                var resultado = await _consultasCiudades.ObtenerCiudadPorId(id);
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
