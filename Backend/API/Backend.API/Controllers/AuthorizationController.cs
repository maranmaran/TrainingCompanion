using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Authorization.Commands.SignIn;
using Backend.Application.Business.Business.Authorization.Queries;

namespace Backend.API.Controllers
{
    public class AuthorizationController : BaseController
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
        {
            var viewModel = await Mediator.Send(command);
            Response.Cookies.Append("jwt", viewModel.token);

            return Ok(viewModel.response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CurrentUserInformation(string id)
        {
            var response = await Mediator.Send(new CurrentUserQuery(id));

            return Ok(response);
        }
    }
}