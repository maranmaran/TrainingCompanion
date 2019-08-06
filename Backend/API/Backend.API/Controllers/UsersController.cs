using Backend.Application.Business.Business.Authorization.ChangePassword;
using Backend.Application.Business.Business.Users.CreateUser;
using Backend.Application.Business.Business.Users.DeleteUser;
using Backend.Application.Business.Business.Users.GetAllUsers;
using Backend.Application.Business.Business.Users.GetUser;
using Backend.Application.Business.Business.Users.SaveUserSettings;
using Backend.Application.Business.Business.Users.UpdateUser;
using Backend.Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllUsersRequest()), sieveModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await GetSingle(async () => await Mediator.Send(new GetUserRequest(id)));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            return await Create(async () => await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
        {
            return await Update(async () => await Mediator.Send(request));
        }

        [HttpGet("{id}/{accountType}")]
        public async Task<IActionResult> Delete(Guid id, AccountType accountType)
        {
            return await Delete(async () => await Mediator.Send(new DeleteUserRequest(id, accountType)));
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            await Mediator.Send(request);

            return Accepted();
        }

        [HttpPost]
        public async Task<IActionResult> SaveUserSettings([FromBody] SaveUserSettingsRequest request)
        {
            await Mediator.Send(request);

            return Accepted();
        }
    }
}
