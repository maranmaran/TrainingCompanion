using Backend.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Backend.Business.Chat.Chat.GetChatHistory;
using Backend.Business.Chat.Chat.GetFriendList;
using Backend.Business.Chat.Chat.SendChatMessage;
using Backend.Business.Chat.Chat.UploadChatFile;

namespace Backend.API.Controllers
{
    public class ChatController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> SendChatMessage([FromBody] SendChatMessageRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{userId}/{accountType}")]
        public async Task<IActionResult> GetFriendsList(Guid userId, AccountType accountType)
        {
            return Ok(await Mediator.Send(new GetFriendsListRequest(userId, accountType)));
        }

        [HttpGet("{userId}/{receiverId}")]
        public async Task<IActionResult> GetChatHistory(Guid userId, Guid receiverId)
        {
            return Ok(await Mediator.Send(new GetChatHistoryRequest() { UserId = userId, ReceiverId = receiverId }));
        }

        [HttpPost]
        public async Task<IActionResult> UploadChatFile([FromForm(Name = "ng-chat-participant-id")] string userId, [FromForm(Name = "file")] IFormFile file)
        {
            return Ok(await Mediator.Send(new UploadChatFileRequest(userId, file)));
        }
    }
}