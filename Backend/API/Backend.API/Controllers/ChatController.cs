using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Chat.GetChatHistory;
using Backend.Application.Business.Business.Chat.GetFriendList;
using Backend.Application.Business.Business.Chat.SendChatMessage;
using Backend.Application.Business.Business.Chat.UploadChatFile;

namespace Backend.API.Controllers
{
    public class ChatController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> SendChatMessage([FromBody] SendChatMessageRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFriendsList(Guid userId)
        {
            return Ok(await Mediator.Send(new GetFriendsListRequest(userId)));
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
