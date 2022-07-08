using Biosite.Analysis.Gateway.Services.Authentication;
using Biosite.Core.Controller;
using Biosite.Main.Gateway.Response.Organ;
using Microsoft.AspNetCore.Mvc;

namespace Biosite.Analysis.Gateway.Controllers
{
    [ApiController]
    public class OrganController : BaseController
    {
        private readonly OrganService _service;

        public OrganController(OrganService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("organ/get")]
        [ProducesResponseType(typeof(ICollection<OrganResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return await Response(await _service.GetAll(Request.Headers["Authorization"]), _service.Notifications);
        }
    }
}
