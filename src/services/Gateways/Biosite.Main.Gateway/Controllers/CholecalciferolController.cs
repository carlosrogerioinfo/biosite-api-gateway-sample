using Biosite.Core.Controller;
using Health.Library.Domain.Commands.Handlers;
using Health.Library.Domain.Commands.Requests;
using Health.Library.Domain.Commands.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Biosite.Analysis.Gateway.Controllers
{
    [ApiController]
    public class CholecalciferolController : BaseController
    {
        private readonly CholecalciferolSimpleCalculeCommandHandler _cholecalciferolCommandHandler;

        public CholecalciferolController(CholecalciferolSimpleCalculeCommandHandler cholecalciferolCommandHandler)
        {
            _cholecalciferolCommandHandler = cholecalciferolCommandHandler;
        }

        [HttpPost]
        [Route("cholecalciferol/calculate")]
        [ProducesResponseType(typeof(CholecalciferolSimpleCalculeResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Calculate([FromBody] CholecalciferolSimpleCalculeRequest requestCommand)
        {
            return await Response(await _cholecalciferolCommandHandler.Handler(requestCommand), _cholecalciferolCommandHandler.Notifications);
        }
    }
}
