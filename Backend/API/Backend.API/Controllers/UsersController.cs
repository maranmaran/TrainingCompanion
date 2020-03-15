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
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet("{accountType}/{coachId}")]
        public async Task<IActionResult> GetAll(AccountType accountType, Guid coachId, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetAllUsersRequest(accountType, coachId), cancellationToken));
        }

        [HttpGet("{id}/{accountType}")]
        public async Task<IActionResult> Get(Guid id, AccountType accountType, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetUserRequest(id, accountType), cancellationToken));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{id}/{accountType}")]
        public async Task<IActionResult> Delete(Guid id, AccountType accountType, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new DeleteUserRequest(id, accountType), cancellationToken));
        }

        [HttpGet("{id}/{active}")]
        public async Task<IActionResult> SetActive(Guid id, bool active, CancellationToken cancellationToken = default)
        {
            return Accepted(await Mediator.Send(new SetActiveUserRequest(id, active), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> SaveUserSetting([FromBody] SaveUserSettingsRequest request, CancellationToken cancellationToken = default)
        {
            return Accepted(await Mediator.Send(request, cancellationToken));
        }
    }
}