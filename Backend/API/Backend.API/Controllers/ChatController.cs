using Backend.Business.Chat.ChatRequests.GetChatHistoryPaged;
using Backend.Business.Chat.ChatRequests.GetFriendList;
using Backend.Business.Chat.ChatRequests.SendChatMessage;
using Backend.Business.Chat.ChatRequests.UploadChatFile;
using Backend.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Business.Chat.ChatRequests.GetChatHistoryFull;

namespace Backend.API.Controllers
{
    public class ChatController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> SendChatMessage([FromBody] SendChatMessageRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpGet("{userId}/{accountType}")]
        public async Task<IActionResult> GetFriendsList(Guid userId, AccountType accountType, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetFriendsListRequest(userId, accountType), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> GetChatHistoryFull([FromBody] GetChatHistoryFullRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> GetChatHistoryPaged([FromBody] GetChatHistoryPagedRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> UploadChatFile(
            [FromForm(Name = "userId")] string userId,
            [FromForm(Name = "file")] IFormFile file,
            CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new UploadChatFileRequest(userId, file), cancellationToken));
        }
    }
}