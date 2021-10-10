using AutoMapper;
using CodeFirst.Core.DTOs.Step.Request;
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
    public class StepController : ControllerBase
    {
        private readonly IStepService _step;
        private readonly IMapper _mapper;
        private readonly ILogger<StepController> _logger;

        public StepController(
            IStepService step,
            IMapper mapper,
            ILogger<StepController> logger

            )
        {
            _step = step;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene el listado Step de acuerdo a los filtros.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get api/Step/1
        ///
        /// </remarks>
        /// <returns>Retorna Objeto Step solicitado</returns>
        /// <param name="filters">Identificador del objeto Step.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpGet(Name = nameof(GetStepAll))]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        public IActionResult GetStepAll([FromQuery] SetpQueryFilter filters)
        {


            _logger.LogWarning("_logger: LogWarning");
            _logger.LogError("_logger: LogError");
            _logger.LogCritical("_logger: LogCritical");

            var step = _step.GetSteps(filters, Url.RouteUrl(nameof(GetStepAll)).ToString());
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(step.Meta));
            return Ok(step);
        }

        /// <summary>
        /// Obtiene un objeto Step por su Id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get api/Step/1
        ///
        /// </remarks>
        /// <returns>Retorna Objeto Step solicitado</returns>
        /// <param name="id">Identificador del objeto Step.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _step.GetStepAsync(id).ConfigureAwait(false));
        }

        /// <summary>
        /// Crea un nuevo objeto Step.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post api/Step/
        ///
        /// </remarks>
        /// <returns>Retorna el Objeto Step solicitado</returns>
        /// <param name="step">El objeto Step.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(StepAddDtoRequest step)
        {
            return Ok(await _step.InsertStepAsync(step));
        }

        /// <summary>
        /// Actualiza el objeto Step.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put api/Step/
        ///
        /// </remarks>
        /// <returns>Retorna el Objeto Step solicitado</returns>
        /// <param name="step">El objeto Step.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpPut]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(StepUpdateDtoRequest step)
        {
            return Ok(await _step.UpdateStepAsync(step));
        }

        /// <summary>
        /// Elimina el objeto Step.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put api/Step/
        ///
        /// </remarks>
        /// <returns>Retorna el Objeto Step solicitado</returns>
        /// <param name="id">El objeto Step.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpDelete]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _step.DeleteStepAsync(id));
        }
    }
}