using AutoMapper;
using Backend.Common.Extensions;
using Backend.Domain;
using Backend.Domain.Enum;
using Backend.Service.AmazonS3.Interfaces;
using Backend.Service.AmazonS3.Models;
using Backend.Service.Chat.NgChatModels;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Chat.UploadChatFile
{
    public class UploadChatFileRequestHandler : IRequestHandler<UploadChatFileRequest, MessageViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IS3AccessService _s3AccessService;

        public UploadChatFileRequestHandler(IMapper mapper, IS3AccessService s3AccessService, IApplicationDbContext context)
        {
            _mapper = mapper;
            _s3AccessService = s3AccessService;
            _context = context;
        }

        public async Task<MessageViewModel> Handle(UploadChatFileRequest request, CancellationToken cancellationToken)
        {
            try
            {
                //file Type
                var type = request.File.IsImage() ?
                    MessageType.Image :
                    request.File.IsVideo() ?
                        MessageType.Video :
                        MessageType.File;

                // construct s3 filename
                var filename = new StringBuilder($"{request.UserId}/{Guid.NewGuid()}");
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
                var fileRequest = new S3FileRequest($"chat/{filename.ToString()}");

                // write to s3
                await _s3AccessService.WriteStreamToS3(fileRequest, request.File.OpenReadStream());
                var presignedUrl = await _s3AccessService.GetPresignedUrlAsync(fileRequest);

                // construct message to return
                var fileMessage = new MessageViewModel()
                {
                    DateSent = DateTime.UtcNow,
                    S3Filename = fileRequest.FileName, // s3 filename which will be stored inside sql. It will then be presigned every fetch.. because it doesn't cost any
                    DownloadUrl = presignedUrl, 
                    ToId = request.UserId,
                    Message = request.File.FileName,
                    FileSizeInBytes = Convert.ToInt32(request.File.Length),
                    Type = Convert.ToInt32(type)
                };

                //send message
                return fileMessage;
            }
            catch (Exception e)
            {
                throw new CreateFailureException("Could not upload file from chat.", e);
            }
        }
    }
}