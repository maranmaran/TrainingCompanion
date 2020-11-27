using Backend.Business.Media.MediaRequests.GetTrainingMedia;
using Backend.Business.Media.MediaRequests.GetUserMediaByType;
using Backend.Business.Media.MediaRequests.UploadTrainingMedia;
using Backend.Business.Media.MediaRequests.UploadUserAvatar;
using Backend.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class MediaController : BaseController
    {
        [HttpGet("{id}/{type}")]
        public async Task<IActionResult> GetUserMediaByType(Guid id, MediaType type, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetUserMediaByTypeRequest() { MediaType = type, UserId = id }, cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainingMedia(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetTrainingMediaRequest(id), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> UploadTrainingMedia(
            [FromForm] Guid userId,
            [FromForm] Guid trainingId,
            [FromForm] IFormFile file,
            [FromForm] string extension,
            [FromForm] MediaType type,
            CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new UploadTrainingMedia(userId, file, extension, type)
            {
                TrainingId = trainingId
            }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> UploadExerciseMedia(
              [FromForm] Guid userId,
              [FromForm] Guid exerciseId,
              [FromForm] IFormFile file,
              [FromForm] string extension,
              [FromForm] MediaType type,
              CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new UploadTrainingMedia(userId, file, extension, type)
            {
                ExerciseId = exerciseId
            }, cancellationToken));
        }


        [HttpPost]
        public async Task<IActionResult> UploadAvatar(
            [FromForm] Guid userId,
            [FromForm] string base64Image,
            CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new UploadUserAvatarRequest()
            {
                UserId = userId,
                Base64 = base64Image,
            }, cancellationToken));
        }
    }
}