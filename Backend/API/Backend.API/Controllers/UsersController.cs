using Backend.Business.Users.UsersRequests.CreateUser;
using Backend.Business.Users.UsersRequests.DeleteUser;
using Backend.Business.Users.UsersRequests.GetAllUsers;
using Backend.Business.Users.UsersRequests.GetUser;
using Backend.Business.Users.UsersRequests.SaveUserSettings;
using Backend.Business.Users.UsersRequests.SetActive;
using Backend.Business.Users.UsersRequests.UpdateUser;
using Backend.Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet("{accountType}/{coachId}")]
        public async Task<IActionResult> GetAll(AccountType accountType, Guid coachId)
        {
            return Ok(await Mediator.Send(new GetAllUsersRequest(accountType, coachId)));
        }

        [HttpGet("{id}/{accountType}")]
        public async Task<IActionResult> Get(Guid id, AccountType accountType)
        {
            return Ok(await Mediator.Send(new GetUserRequest(id, accountType)));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete("{id}/{accountType}")]
        public async Task<IActionResult> Delete(Guid id, AccountType accountType)
        {
            return Ok(await Mediator.Send(new DeleteUserRequest(id, accountType)));
        }

        [HttpGet("{id}/{active}")]
        public async Task<IActionResult> SetActive(Guid id, bool active)
        {
            return Accepted(await Mediator.Send(new SetActiveUserRequest(id, active)));
        }

        [HttpPost]
        public async Task<IActionResult> SaveUserSetting([FromBody] SaveUserSettingsRequest request)
        {
            return Accepted(await Mediator.Send(request));
        }
    }
}