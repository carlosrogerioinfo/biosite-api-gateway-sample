using Biosite.Authentication.Api.Application.Commands.Handlers;
using Biosite.Core.Commands.Response;
using Biosite.Core.Constants;
using Biosite.Core.Controller;
using Biosite.Core.JwtBearerToken.Service;
using Biosite.Domain.Commands.Request.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Biosite.Api.Controllers
{
    [Authorize(Roles = Constants.AdminProj)]
    public class AuthenticationController : BaseController
    {
        private readonly UserCommandHandler _handler;
        private readonly IJwtService _service;

        public AuthenticationController(UserCommandHandler handler, IJwtService service)
            : base()
        {
            _handler = handler;
            _service = service;
        }

        /// <summary>
        /// Retorna as informações do(a) usuário(a) pelo email e senha.
        /// </summary>
        /// <response code="200">As informações do(a) usuário(a) que retornou com sucesso.</response>
        /// <response code="500">Ocorreu um erro interno na consulta.</response>
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] AuthenticateUserRequest command)
        {
            var data = await _handler.Handle(command.Email, command.Password);

            if (data != null)
            {
                data.Token = _service.GenerateToken(data);

                //workaround, remove/change later
                var response = new
                {
                    id = data.Id,
                    name = data.Name,
                    email = data.Email,
                    age = data.Age,
                    genderDescription = data.GenderDescription,
                    pregnant = data.IsPregnant,
                    height = data.Height,
                    weight = Math.Round(data.Weight, 2),
                    imc = data.Imc,
                    imcResult = data.ImcResult,
                    lastLoginAt = data.LastLoginDate.ToString("dd/MM/yyyy HH:mm"),
                    token = data.Token,
                    plan = data.PlanResponse
                };

                return await Response(response, _handler.Notifications);
            }

            return await Response(data, _handler.Notifications);

        }
    }
}
