using Backend.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Business.Chat.ChatRequests.GetChatHistory;
using Backend.Business.Chat.ChatRequests.GetFriendList;
using Backend.Business.Chat.ChatRequests.SendChatMessage;
using Backend.Business.Chat.ChatRequests.UploadChatFile;

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

        [HttpGet("{userId}/{receiverId}")]
        public async Task<IActionResult> GetChatHistory(Guid userId, Guid receiverId, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetChatHistoryRequest() { UserId = userId, ReceiverId = receiverId }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> UploadChatFile(
            [FromForm(Name = "ng-chat-participant-id")] string userId, 
            [FromForm(Name = "file")] IFormFile file, 
            CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new UploadChatFileRequest(userId, file), cancellationToken));
        }
    }
}