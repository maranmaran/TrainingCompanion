using AutoMapper;
using Backend.Domain.Enum;
using Backend.Service.AmazonS3.Interfaces;
using Backend.Service.AmazonS3.Models;
using Backend.Service.Chat.NgChatModels;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Chat.Commands.UploadChatFileCommand
{
    public class UploadChatFileCommandHandler : IRequestHandler<UploadChatFileCommand, MessageViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IS3AccessService _s3AccessService;

        public UploadChatFileCommandHandler(IMapper mapper, IS3AccessService s3AccessService)
        {
            _mapper = mapper;
            _s3AccessService = s3AccessService;
        }

        public async Task<MessageViewModel> Handle(UploadChatFileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // save file to S3 and retrieve presigned URL
                var fileRequest = new S3FileRequest($"Chat/{request.UserId}/{request.File.FileName}");
                await _s3AccessService.WriteStreamToS3(fileRequest, request.File.OpenReadStream());
                var presignedUrl = await _s3AccessService.GetPresignedUrlAsync(fileRequest);

                return new MessageViewModel()
                {
                    DateSent = DateTime.UtcNow,
                    DownloadUrl = presignedUrl,
                    ToId = request.UserId,
                    Message = request.File.FileName,
                    FileSizeInBytes = Convert.ToInt32(request.File.Length),
                    Type = Convert.ToInt32(MessageContentType.File) // 2

                };
            }
            catch (Exception e)
            {
                throw new CreateFailureException("Could not upload file from chat.", e);
            }
        }
    }
}