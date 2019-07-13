using Backend.Application.Business.Business.Authorization.SignIn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Authorization.CurrentUser;

namespace Backend.API.Controllers
{
    public class AuthorizationController : BaseController
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            var viewModel = await Mediator.Send(request);
            Response.Cookies.Append("jwt", viewModel.token);

            return Ok(viewModel.response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CurrentUserInformation(string id)
        {
            var response = await Mediator.Send(new CurrentUserRequest(id));

            return Ok(response);
        }
    }
}