using Backend.Application.Business.Business.Chat.Commands.SendChatMessageCommand;
using Backend.Application.Business.Business.Chat.Commands.UploadChatFileCommand;
using Backend.Application.Business.Business.Chat.Queries.GetChatHistoryQuery;
using Backend.Application.Business.Business.Chat.Queries.GetFriendListQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class ChatController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> SendChatMessage([FromBody] SendChatMessageCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFriendsList(Guid userId)
        {
            return Ok(await Mediator.Send(new GetFriendsListQuery(userId)));
        }

        [HttpGet("{userId}/{receiverId}")]
        public async Task<IActionResult> GetChatHistory(Guid userId, Guid receiverId)
        {
            return Ok(await Mediator.Send(new GetChatHistoryQuery() { UserId = userId, ReceiverId = receiverId }));
        }

        [HttpPost]
        public async Task<IActionResult> UploadChatFile([FromForm(Name = "ng-chat-participant-id")] string userId, [FromForm(Name = "file")] IFormFile file)
        {
            return Ok(await Mediator.Send(new UploadChatFileCommand(userId, file)));
        }
    }
}
