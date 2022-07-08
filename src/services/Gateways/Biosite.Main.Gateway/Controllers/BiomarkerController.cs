using Biosite.Core.Controller;
using Biosite.Main.Gateway.Response.Biomarker;
using Biosite.Main.Gateway.Service.Biomarker;
using Microsoft.AspNetCore.Mvc;

namespace Biosite.Analysis.Gateway.Controllers
{
    [ApiController]
    public class BiomarkerController : BaseController
    {
        private readonly BiomarkerService _service;

        public BiomarkerController(BiomarkerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("biomarker/get")]
        [ProducesResponseType(typeof(ICollection<BiomarkerResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return await Response(await _service.GetAll(Request.Headers["Authorization"]), _service.Notifications);
        }
    }
}
