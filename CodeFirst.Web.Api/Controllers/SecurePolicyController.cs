using CodeFirst.Core.DTOs.Secure.Request;
using CodeFirst.Core.Interfaces.Services;
using CodeFirst.Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeFirst.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurePolicyController : ControllerBase
    {
        private readonly ISecureServices _secure;
        public SecurePolicyController(
            ISecureServices secure
            )
        {
            _secure = secure;
        }
        /// <summary>
        /// Crea un nuevo objeto Secure.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post api/SecurePolicy/
        ///
        /// </remarks>
        /// <returns>Retorna el Objeto Secure policy solicitado</returns>
        /// <param name="Secure">El objeto secure.</param>
        /// <response code="500">InternalServerError. Ha ocurrido una exception no controlada.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(SecureDtoRequest Secure)
        {
            return Ok(await _secure.CreateSecure(Secure));
        }
    }
}
