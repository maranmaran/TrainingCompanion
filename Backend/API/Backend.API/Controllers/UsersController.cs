using Backend.Application.Business.Business.Users.Commands.Create;
using Backend.Application.Business.Business.Users.Commands.Delete;
using Backend.Application.Business.Business.Users.Commands.SaveUserSettings;
using Backend.Application.Business.Business.Users.Commands.Update;
using Backend.Application.Business.Business.Users.Queries.Get;
using Backend.Application.Business.Business.Users.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Authorization.Commands.ChangePassword;

namespace Backend.API.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllUsersQuery()), sieveModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await GetSingle(async () => await Mediator.Send(new GetUserQuery(id)));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            return await Create(async () => await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            return await Update(async () => await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await Delete(async () => await Mediator.Send(new DeleteUserCommand(id)));
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            await Mediator.Send(command);

            return Accepted();
        }

        [HttpPost]
        public async Task<IActionResult> SaveUserSettings([FromBody] SaveUserSettingsCommand command)
        {
            await Mediator.Send(command);

            return Accepted();
        }
    }
}
