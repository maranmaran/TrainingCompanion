using Backend.Domain;
using Backend.Domain.Entities.Media;
using Backend.Domain.Enum;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Backend.Library.AmazonS3.Interfaces;
using Backend.Library.ImageProcessing.Interfaces;

namespace Backend.Business.Media.MediaRequests.UploadUserAvatar
{
    public class UploadUserAvatarRequestHandler : IRequestHandler<UploadUserAvatarRequest, string>
    {

        private readonly IApplicationDbContext _context;
        private readonly IS3Service _s3;
        private readonly IImageProcessingService _imageProcessing;

        public UploadUserAvatarRequestHandler(IS3Service s3, IApplicationDbContext context, IImageProcessingService imageProcessing)
        {
            _s3 = s3;
            _context = context;
            _imageProcessing = imageProcessing;
        }

        public async Task<string> Handle(UploadUserAvatarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // save everything to s3
                var key = GetS3Key(request);

                var byteArr = Convert.FromBase64String(request.Base64.Replace("data:image/jpeg;base64,", string.Empty));
                var compressedImage = await _imageProcessing.Compress(new MemoryStream(byteArr));

                await _s3.WriteToS3(key, compressedImage);
                var presignedUrl = await _s3.GetPresignedUrlAsync(key);

                // add newly created media
                var media = new MediaFile()
                {
                    ApplicationUserId = request.UserId,
                    DownloadUrl = presignedUrl,
                    Type = MediaType.Image,
                    DateModified = DateTime.UtcNow,
                    DateUploaded = DateTime.UtcNow,
                    Filename = $"Avatar - {DateTime.UtcNow:MM/dd/yyyy}",
                    FtpFilePath = key,
                };
                await _context.MediaFiles.AddAsync(media, cancellationToken);

                // fetch and update user Avatar KEY for s3.. which will be presigned on every fetch of user
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
                user.Avatar = key;
                _context.Users.Update(user);
                await _context.SaveChangesAsync(cancellationToken);

                return presignedUrl;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(UploadUserAvatarRequest), e);
            }
        }
        public string GetS3Key(UploadUserAvatarRequest request)
        {
            var builder = new StringBuilder();

            if (request.UserId != Guid.Empty)
                builder.Append($"media/{request.UserId}/avatar/{Guid.NewGuid()}");

            return builder.ToString();
        }
    }
}