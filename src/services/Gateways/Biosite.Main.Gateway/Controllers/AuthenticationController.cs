using Biosite.Analysis.Gateway.Request;
using Biosite.Analysis.Gateway.Services.Authentication;
using Biosite.Core.Controller;
using Biosite.Main.Gateway.Response.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Biosite.Analysis.Gateway.Controllers
{
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly AuthenticationService _service;

        public AuthenticationController(AuthenticationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("authentication/login")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] AuthenticationRequest requestCommand)
        {
            return await Response(await _service.Authentication(requestCommand), _service.Notifications);
        }
    }
}
