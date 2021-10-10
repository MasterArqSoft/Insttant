using AutoMapper;
using CodeFirst.Core.DTOs.StepToFlow.Request;
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
    public class AssingStepToFlowController : ControllerBase
    {
        private readonly IStepToFlowService _stepToFlow;
        private readonly IMapper _mapper;
        private readonly ILogger<AssingStepToFlowController> _logger;

        public AssingStepToFlowController(
            IStepToFlowService stepToFlow,
            IMapper mapper,
            ILogger<AssingStepToFlowController> logger

            )
        {
            _stepToFlow = stepToFlow;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene el listado StepToFlow de acuerdo a los filtros.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get api/StepToFlow/1
        ///
        /// </remarks>
        /// <returns>Retorna Objeto StepToFlow solicitado</returns>
        /// <param name="filters">Identificador del objeto StepToFlow.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpGet(Name = nameof(GetstepToFlowAll))]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        public IActionResult GetstepToFlowAll([FromQuery] StepToFlowQueryFilter filters)
        {


            _logger.LogWarning("_logger: LogWarning");
            _logger.LogError("_logger: LogError");
            _logger.LogCritical("_logger: LogCritical");

            var stepToFlow = _stepToFlow.GetStepToFlows(filters, Url.RouteUrl(nameof(GetstepToFlowAll)).ToString());
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(stepToFlow.Meta));
            return Ok(stepToFlow);
        }

        /// <summary>
        /// Obtiene un objeto StepToFlow por su Id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get api/StepToFlow/1
        ///
        /// </remarks>
        /// <returns>Retorna Objeto StepToFlow solicitado</returns>
        /// <param name="id">Identificador del objeto StepToFlow.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _stepToFlow.GetStepToFlowAsync(id).ConfigureAwait(false));
        }

        /// <summary>
        /// Crea un nuevo objeto StepToFlow.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post api/StepToFlow/
        ///
        /// </remarks>
        /// <returns>Retorna el Objeto StepToFlow solicitado</returns>
        /// <param name="stepToFlow">El objeto StepToFlow.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(StepToFlowAddDtoRequest stepToFlow)
        {
            return Ok(await _stepToFlow.InsertStepToFlowAsync(stepToFlow));
        }

        /// <summary>
        /// Actualiza el objeto StepToFlow.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put api/StepToFlow/
        ///
        /// </remarks>
        /// <returns>Retorna el Objeto StepToFlow solicitado</returns>
        /// <param name="stepToFlow">El objeto StepToFlow.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpPut]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(StepToFlowUpdateDtoRequest stepToFlow)
        {
            return Ok(await _stepToFlow.UpdateStepToFlowAsync(stepToFlow));
        }

        /// <summary>
        /// Elimina el objeto StepToFlow.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put api/StepToFlow/
        ///
        /// </remarks>
        /// <returns>Retorna el Objeto StepToFlow solicitado</returns>
        /// <param name="id">El objeto StepToFlow.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpDelete]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _stepToFlow.DeleteStepToFlowAsync(id));
        }
    }
}