using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.Media;
using Backend.Domain.Enum;
using Backend.Service.AmazonS3.Interfaces;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Media.MediaRequests.UploadUserAvatar
{
    public class UploadUserAvatarRequestHandler : IRequestHandler<UploadUserAvatarRequest, string>
    {

        private readonly IApplicationDbContext _context;
        private readonly IS3Service _s3;

        public UploadUserAvatarRequestHandler(IS3Service s3, IApplicationDbContext context)
        {
            _s3 = s3;
            _context = context;
        }

        public async Task<string> Handle(UploadUserAvatarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // save everything to s3
                var key = GetS3Key(request);
                await _s3.WriteToS3(key, request.File.OpenReadStream());
                var presignedUrl = await _s3.GetPresignedUrlAsync(key);

                // add newly created media
                var media = new MediaFile()
                {
                    ApplicationUserId = request.UserId,
                    DownloadUrl = presignedUrl,
                    Type = MediaType.Image,
                    DateModified = DateTime.UtcNow,
                    DateUploaded = DateTime.UtcNow,
                    Filename = request.File.FileName,
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
                builder.Append($"media/{request.UserId}/avatar");

            return builder.ToString();
        }
    }
}