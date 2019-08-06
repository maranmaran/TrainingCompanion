using Backend.Application.Business.Business.Media;
using Backend.Application.Business.Business.Media.UploadMedia;
using Backend.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Media.GetUserMediaByType;

namespace Backend.API.Controllers
{

    public class MediaController : BaseController
    {
        [HttpGet("{id}/{type}")]
        public async Task<IActionResult> GetUserMediaByType(Guid id, MediaType type, [FromQuery]SieveModel sieveModel)
        {
            return Ok(await Mediator.Send(new GetUserMediaByTypeRequest() { MediaType = type, UserId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> UploadMedia(
            [FromForm] Guid userId,
            [FromForm] IFormFile file,
            [FromForm] string extension,
            [FromForm] MediaType type)
        {
            return Ok(await Mediator.Send(new UploadMediaRequest(userId, file, extension, type)));
        }

    }
}
