using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.Media;
using Backend.Service.AmazonS3.Interfaces;
using Backend.Service.AmazonS3.Models;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Media.MediaRequests.GetUserMediaByType
{
    public class GetUserMediaByTypeRequestHandler : IRequestHandler<GetUserMediaByTypeRequest, IEnumerable<MediaFile>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IS3AccessService _s3AccessService;

        public GetUserMediaByTypeRequestHandler(IApplicationDbContext context, IS3AccessService s3AccessService)
        {
            _context = context;
            _s3AccessService = s3AccessService;
        }

        public async Task<IEnumerable<MediaFile>> Handle(GetUserMediaByTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var media = await _context.MediaFiles
                    .Where(x => x.ApplicationUserId == request.UserId && x.Type == request.MediaType).ToListAsync(cancellationToken);

                //TODO: Possible performance issue. Fetching all and executing Select * query and then iterating all O(n) and assigning something

                foreach (var mediaFile in media)
                {
                    if (_s3AccessService.CheckIfPresignedUrlIsExpired(mediaFile.DownloadUrl))
                        mediaFile.DownloadUrl = await _s3AccessService.GetPresignedUrlAsync(new S3FileRequest(mediaFile.FtpFilePath));
                }

                return await Task.FromResult(media);
            }
            catch (Exception e)
            {
                throw new FetchFailureException($"Could not fetch list of media of type {request.MediaType} for user {request.UserId}", e);
            }
        }
    }
}