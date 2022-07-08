using Biosite.Authentication.Api.Application.Commands.Handlers;
using Biosite.Core.Commands.Response;
using Biosite.Core.Constants;
using Biosite.Core.Controller;
using Biosite.Domain.Commands.Request.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biosite.Api.Controllers
{
    [Authorize(Roles = Constants.AdminProj)]
    public class UserController : BaseController
    {
        private readonly UserCommandHandler _handler;

        public UserController(UserCommandHandler handler)
            : base()
        {
            _handler = handler;
        }

        /// <summary>
        /// Retorna todos os usuários (acesso exclusivo).
        /// </summary>
        /// <response code="200">A lista dos usuários foram retornados com sucesso.</response>
        /// <response code="500">Ocorreu um erro interno na consulta.</response>
        [HttpGet]
        [Route("user/crud/get")]
        [ProducesResponseType(typeof(IEnumerable<UserResponse>), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllUser(int? skip = null, int? take = null)
        {
            var data = await _handler.Handle(skip, take);
            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        /// <summary>
        /// Cria um novo usuário (acesso exclusivo).
        /// </summary>
        /// <response code="200">As informações do(a) usuário(a) que foi criado com sucesso.</response>
        /// <response code="500">Ocorreu um erro interno na consulta.</response>
        [HttpPost]
        [Route("user/crud/create")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] RegisterUserRequest command)
        {
            var data = await _handler.Handle(command);
            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        /// <summary>
        /// Atualiza informações de um novo usuário (acesso exclusivo).
        /// </summary>
        /// <response code="200">As informações do(a) usuário(a) que foi atualizado com sucesso.</response>
        /// <response code="500">Ocorreu um erro interno na consulta.</response>
        [HttpPut]
        [Route("user/crud/put")]
        [ProducesResponseType(typeof(IEnumerable<UserResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromBody] UpdateUserRequest command)
        {
            var data = await _handler.Handle(command);
            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        /// <summary>
        /// Remove um usuário (acesso exclusivo).
        /// </summary>
        /// <response code="200">As informações do(a) usuário(a) que foi removido(a) com sucesso.</response>
        /// <response code="500">Ocorreu um erro interno na consulta.</response>
        [HttpDelete]
        [Route("user/crud/delete")]
        [ProducesResponseType(typeof(IEnumerable<UserResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteUserRequest command)
        {
            var data = await _handler.Handle(command);
            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }
    }
}
