using Backend.Business.Authorization.Authorization.ChangePassword;
using Backend.Business.Authorization.Authorization.CurrentUser;
using Backend.Business.Authorization.Authorization.ResetPassword;
using Backend.Business.Authorization.Authorization.SetPassword;
using Backend.Business.Authorization.Authorization.SignIn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class AuthorizationController : BaseController
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            var (response, token) = await Mediator.Send(request);
            Response.Cookies.Append("jwt", token);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CurrentUserInformation(Guid id)
        {
            var response = await Mediator.Send(new CurrentUserRequest(id));

            return Ok(response);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> ResetPassword(string email)
        {
            var response = await Mediator.Send(new ResetPasswordRequest(email));

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SetPassword(SetPasswordRequest request)
        {
            var (response, token) = await Mediator.Send(request);
            Response.Cookies.Append("jwt", token);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            await Mediator.Send(request);

            return Accepted();
        }
    }
}