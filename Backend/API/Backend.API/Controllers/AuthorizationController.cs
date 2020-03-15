using Backend.Business.Authorization.AuthorizationRequests.ChangePassword;
using Backend.Business.Authorization.AuthorizationRequests.CurrentUser;
using Backend.Business.Authorization.AuthorizationRequests.ResetPassword;
using Backend.Business.Authorization.AuthorizationRequests.SetPassword;
using Backend.Business.Authorization.AuthorizationRequests.SignIn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class AuthorizationController : BaseController
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request, CancellationToken cancellationToken = default)
        {
            var (response, token) = await Mediator.Send(request, cancellationToken);
            Response.Cookies.Append("jwt", token);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CurrentUserInformation(Guid id, CancellationToken cancellationToken = default)
        {
            var response = await Mediator.Send(new CurrentUserRequest(id), cancellationToken);

            return Ok(response);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> ResetPassword(string email, CancellationToken cancellationToken = default)
        {
            var response = await Mediator.Send(new ResetPasswordRequest(email), cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SetPassword([FromBody] SetPasswordRequest request, CancellationToken cancellationToken = default)
        {
            var (response, token) = await Mediator.Send(request, cancellationToken);
            Response.Cookies.Append("jwt", token);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request, CancellationToken cancellationToken = default)
        {
            await Mediator.Send(request, cancellationToken);

            return Accepted();
        }
    }
}