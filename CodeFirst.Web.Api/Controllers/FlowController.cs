using AutoMapper;
using CodeFirst.Core.DTOs.Flow.Request;
using CodeFirst.Core.Interfaces.Services;
using CodeFirst.Core.QueryFilters;
using CodeFirst.Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CodeFirst.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FlowController : ControllerBase
    {
        private readonly IFlowService _flow;
        private readonly IMapper _mapper;
        private readonly ILogger<FlowController> _logger;

        public FlowController(
            IFlowService flow,
            IMapper mapper,
            ILogger<FlowController> logger

            )
        {
            _flow = flow;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene el listado Flow de acuerdo a los filtros.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get api/Flow/1
        ///
        /// </remarks>
        /// <returns>Retorna Objeto Flow solicitado</returns>
        /// <param name="filters">Identificador del objeto Flow.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpGet(Name = nameof(GetFlowAll))]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        public IActionResult GetFlowAll([FromQuery] FlowQueryFilter filters)
        {


            _logger.LogWarning("_logger: LogWarning");
            _logger.LogError("_logger: LogError");
            _logger.LogCritical("_logger: LogCritical");

            var flow = _flow.GetFlows(filters, Url.RouteUrl(nameof(GetFlowAll)).ToString());
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(flow.Meta));
            return Ok(flow);
        }

        /// <summary>
        /// Obtiene un objeto Flow por su Id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get api/Flow/1
        ///
        /// </remarks>
        /// <returns>Retorna Objeto Flow solicitado</returns>
        /// <param name="id">Identificador del objeto Flow.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _flow.GetFlowAsync(id).ConfigureAwait(false));
        }

        /// <summary>
        /// Crea un nuevo objeto Flow.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post api/Flow/
        ///
        /// </remarks>
        /// <returns>Retorna el Objeto Flow solicitado</returns>
        /// <param name="flow">El objeto Flow.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(FlowdAddDtoRequest flow)
        {
            return Ok(await _flow.InsertFlowAsync(flow));
        }

        /// <summary>
        /// Actualiza el objeto Flow.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put api/Flow/
        ///
        /// </remarks>
        /// <returns>Retorna el Objeto Flow solicitado</returns>
        /// <param name="flow">El objeto Flow.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpPut]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(FlowUpdateDtoRequest flow)
        {
            return Ok(await _flow.UpdateFlowAsync(flow));
        }

        /// <summary>
        /// Elimina el objeto Flow.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put api/Flow/
        ///
        /// </remarks>
        /// <returns>Retorna el Objeto Flow solicitado</returns>
        /// <param name="id">El objeto Flow.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpDelete]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _flow.DeleteFlowAsync(id));
        }
    }
}