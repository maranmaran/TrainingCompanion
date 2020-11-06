using Backend.Business.Chat.Models;
using Backend.Business.Media.MediaRequests.UploadChatMedia;
using Backend.Common.Extensions;
using Backend.Domain.Entities.Chat;
using Backend.Domain.Enum;
using Backend.Domain.Extensions;
using Backend.Infrastructure.Exceptions;
using Backend.Library.AmazonS3.Interfaces;
using MediatR;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Chat.ChatRequests.UploadChatFile
{
    public class UploadChatFileRequestHandler : IRequestHandler<UploadChatFileRequest, MessageViewModel>
    {
        private readonly IMediator _mediator;
        private readonly IS3Service _s3Service;

        public UploadChatFileRequestHandler(IMediator mediator, IS3Service s3Service)
        {
            _mediator = mediator;
            _s3Service = s3Service;
        }

        public async Task<MessageViewModel> Handle(UploadChatFileRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var info = GetFileInformationForS3(request);

                // write to s3
                var presignedUrl = await _mediator.Send(
                    new UploadChatMediaRequest(
                        info.key,
                        info.type.ConvertToMediaType(),
                        request.File.OpenReadStream()
                    ), cancellationToken);

                // construct message to return
                var fileMessage = new MessageViewModel()
                {
                    DateSent = DateTime.UtcNow,
                    S3Filename = info.key, // s3 filename which will be stored inside sql. It will then be presigned every fetch.. because it doesn't cost any
                    DownloadUrl = presignedUrl,
                    ToId = request.UserId,
                    Message = request.File.FileName,
                    FileSizeInBytes = Convert.ToInt32(request.File.Length),
                    Type = Convert.ToInt32(info.type)
                };

                //send message
                return fileMessage;
            }
            catch (Exception e)
            {
                throw new CreateFailureException("Could not upload file from chat.", e);
            }
        }

        public (MessageType type, string key) GetFileInformationForS3(UploadChatFileRequest request)
        {
            //file Type
            var type = request.File.IsImage() ?
                MessageType.Image :
                request.File.IsVideo() ?
                    MessageType.Video :
                    MessageType.File;

            // construct s3 filename
            var filename = new StringBuilder($"{Guid.NewGuid()}");
            switch (type)
            {
                case MessageType.Image:
                    filename.Append(".jpeg");
                    break;

                case MessageType.Video:
                    filename.Append(".mp4");
                    break;

                default:
                    break;
            }

            var key = _s3Service.GetS3Key(nameof(ChatMessage), Guid.Parse(request.UserId), filename.ToString());

            return (type, key);
        }
    }
}