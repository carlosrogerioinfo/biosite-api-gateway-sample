using FluentValidator;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biosite.Core.Controller
{
    [ApiController]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        protected BaseController() { }

        protected new async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    await Task.CompletedTask;
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch
                {
                    // Logar o erro ()
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "Ocorreu uma falha interna no servidor." }
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notifications
                });
            }
        }
    }
}
