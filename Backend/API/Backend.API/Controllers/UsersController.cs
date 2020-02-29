using Backend.Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Threading.Tasks;
using Backend.Business.Users.Users.CreateUser;
using Backend.Business.Users.Users.DeleteUser;
using Backend.Business.Users.Users.GetAllUsers;
using Backend.Business.Users.Users.GetUser;
using Backend.Business.Users.Users.SaveUserSettings;
using Backend.Business.Users.Users.SetActive;
using Backend.Business.Users.Users.UpdateUser;

namespace Backend.API.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet("{accountType}/{coachId}")]
        public async Task<IActionResult> GetAll(AccountType accountType, Guid coachId, [FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllUsersRequest(accountType, coachId)), sieveModel);
        }

        [HttpGet("{id}/{acocuntType}")]
        public async Task<IActionResult> Get(Guid id, AccountType accountType)
        {
            return await GetSingle(async () => await Mediator.Send(new GetUserRequest(id, accountType)));
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

        [HttpGet("{id}/{active}")]
        public async Task<IActionResult> SetActive(Guid id, bool active)
        {
            return Accepted(await Mediator.Send(new SetActiveUserRequest(id, active)));
        }

        [HttpPost]
        public async Task<IActionResult> SaveUserSetting([FromBody] SaveUserSettingsRequest request)
        {
            await Mediator.Send(request);

            return Accepted();
        }
    }
}