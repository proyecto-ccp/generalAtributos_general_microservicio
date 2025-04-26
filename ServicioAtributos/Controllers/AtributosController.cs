
using Atributos.Aplicacion.Consultas.AtributosProducto;
using Atributos.Aplicacion.Consultas.TiposDocumento;
using Atributos.Aplicacion.Dto;
using Atributos.Aplicacion.Dto.AtributosProducto;
using Atributos.Aplicacion.Dto.TiposDocumento;
using Atributos.Aplicacion.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ServicioAtributos.Controllers
{
    /// <summary>
    /// Controlador de atributos
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class AtributosController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        public AtributosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene la lista del atributo de producto categorias
        /// </summary>
        /// <response code="200"> 
        /// ListaProductosOut pendiente
        /// </response>
        [HttpGet]
        [Route("Productos/Categorias")]
        [ProducesResponseType(typeof(ListaCategoriaOut), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(BaseOut), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> ListarCategorias()
        {
            var output = await _mediator.Send(new CategoriaConsulta());

            if (output.Resultado == Resultado.Exitoso)
            {
                return Ok(output);
            }
            else if (output.Resultado == Resultado.SinRegistros) 
            {
                return NotFound( new { output.Resultado, output.Mensaje, output.Status } );
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Obtiene la lista del atributo de producto medidas
        /// </summary>
        /// <response code="200"> 
        /// ListaProductosOut pendiente
        /// </response>
        [HttpGet]
        [Route("Productos/Medidas")]
        [ProducesResponseType(typeof(ListaMedidasOut), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(BaseOut), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> ListarMedidas()
        {
            var output = await _mediator.Send(new MedidaConsulta());

            if (output.Resultado == Resultado.Exitoso)
            {
                return Ok(output);
            }
            else if (output.Resultado == Resultado.SinRegistros)
            {
                return NotFound(new { output.Resultado, output.Mensaje, output.Status });
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Obtiene la lista del atributo de producto marcas
        /// </summary>
        /// <response code="200"> 
        /// ListaProductosOut pendiente
        /// </response>
        [HttpGet]
        [Route("Productos/Marcas")]
        [ProducesResponseType(typeof(ListaMarcaOut), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(BaseOut), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> ListarMarcas()
        {
            var output = await _mediator.Send(new MarcaConsulta());

            if (output.Resultado == Resultado.Exitoso)
            {
                return Ok(output);
            }
            else if (output.Resultado == Resultado.SinRegistros)
            {
                return NotFound(new { output.Resultado, output.Mensaje, output.Status });
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Obtiene la lista del atributo de producto colores
        /// </summary>
        /// <response code="200"> 
        /// ListaProductosOut pendiente
        /// </response>
        [HttpGet]
        [Route("Productos/Colores")]
        [ProducesResponseType(typeof(ListaColorOut), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(BaseOut), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> ListarColores()
        {
            var output = await _mediator.Send(new ColorConsulta());

            if (output.Resultado == Resultado.Exitoso)
            {
                return Ok(output);
            }
            else if (output.Resultado == Resultado.SinRegistros)
            {
                return NotFound(new { output.Resultado, output.Mensaje, output.Status });
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Obtiene la lista del atributo de producto modelos
        /// </summary>
        /// <response code="200"> 
        /// ListaProductosOut pendiente
        /// </response>
        [HttpGet]
        [Route("Productos/Modelos")]
        [ProducesResponseType(typeof(ListaModelosOut), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(BaseOut), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> ListarModelos()
        {
            var output = await _mediator.Send(new ModeloConsulta());

            if (output.Resultado == Resultado.Exitoso)
            {
                return Ok(output);
            }
            else if (output.Resultado == Resultado.SinRegistros)
            {
                return NotFound(new { output.Resultado, output.Mensaje, output.Status });
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Obtiene la lista del atributo de producto materiales
        /// </summary>
        /// <response code="200"> 
        /// ListaProductosOut pendiente
        /// </response>
        [HttpGet]
        [Route("Productos/Materiales")]
        [ProducesResponseType(typeof(ListaMaterialOut), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(BaseOut), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> ListarMateriales()
        {
            var output = await _mediator.Send(new MaterialConsulta());

            if (output.Resultado == Resultado.Exitoso)
            {
                return Ok(output);
            }
            else if (output.Resultado == Resultado.SinRegistros)
            {
                return NotFound(new { output.Resultado, output.Mensaje, output.Status });
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Obtiene la lista de tipos de documentos  
        /// </summary>
        [HttpGet]
        [Route("TiposDocumento")]
        [ProducesResponseType(typeof(TipoDocumentoOutList), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(BaseOut), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> ObtenerTiposDocumentos()
        {
            var output = await _mediator.Send(new TiposDocumentoConsulta());

            if (output.Resultado == Resultado.Exitoso)
            {
                return Ok(output);
            }
            else if (output.Resultado == Resultado.SinRegistros)
            {
                return NotFound(new { output.Resultado, output.Mensaje, output.Status });
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }

        }
    }
}
