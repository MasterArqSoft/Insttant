using AutoMapper;
using CodeFirst.Core.DTOs.Field.Request;
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
    public class FieldController : ControllerBase
    {
        private readonly IFieldService _Field;
        private readonly IMapper _mapper;
        private readonly ILogger<FieldController> _logger;

        public FieldController(
            IFieldService field,
            IMapper mapper,
            ILogger<FieldController> logger

            )
        {
            _Field = field;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene el listado Field de acuerdo a los filtros.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get api/Field/1
        ///
        /// </remarks>
        /// <returns>Retorna Objeto Field solicitado</returns>
        /// <param name="filters">Identificador del objeto Field.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpGet(Name = nameof(GetFieldAll))]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        public IActionResult GetFieldAll([FromQuery] FieldQueryFilter filters)
        {


            _logger.LogWarning("_logger: LogWarning");
            _logger.LogError("_logger: LogError");
            _logger.LogCritical("_logger: LogCritical");

            var field = _Field.GetFields(filters, Url.RouteUrl(nameof(GetFieldAll)).ToString());
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(field.Meta));
            return Ok(field);
        }

        /// <summary>
        /// Obtiene un objeto Field por su Id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get api/Field/1
        ///
        /// </remarks>
        /// <returns>Retorna Objeto Field solicitado</returns>
        /// <param name="id">Identificador del objeto Field.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _Field.GetFieldAsync(id).ConfigureAwait(false));
        }

        /// <summary>
        /// Crea un nuevo objeto Field.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post api/Field/
        ///
        /// </remarks>
        /// <returns>Retorna el Objeto field solicitado</returns>
        /// <param name="field">El objeto field.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(FieldAddDtoRequest field)
        {
            return Ok(await _Field.InsertFieldAsync(field));
        }

        /// <summary>
        /// Actualiza el objeto Field.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put api/Field/
        ///
        /// </remarks>
        /// <returns>Retorna el Objeto Field solicitado</returns>
        /// <param name="field">El objeto Field.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpPut]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(FieldUpdateDtoRequest field)
        {
            return Ok(await _Field.UpdateFieldAsync(field));
        }

        /// <summary>
        /// Elimina el objeto Field.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put api/Field/
        ///
        /// </remarks>
        /// <returns>Retorna el Objeto Field solicitado</returns>
        /// <param name="id">El objeto Field.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpDelete]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _Field.DeleteFieldAsync(id));
        }
    }
}