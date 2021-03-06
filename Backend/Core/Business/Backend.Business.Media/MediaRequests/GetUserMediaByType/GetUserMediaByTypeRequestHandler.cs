﻿using Backend.Domain;
using Backend.Domain.Entities.Media;
using Backend.Infrastructure.Exceptions;
using Backend.Library.AmazonS3.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Media.MediaRequests.GetUserMediaByType
{
    public class GetUserMediaByTypeRequestHandler : IRequestHandler<GetUserMediaByTypeRequest, IEnumerable<MediaFile>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IStorage _storage;

        public GetUserMediaByTypeRequestHandler(IApplicationDbContext context, IStorage storage)
        {
            _context = context;
            _storage = storage;
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
                    if (_storage.IsUrlExpired(mediaFile.DownloadUrl))
                        mediaFile.DownloadUrl = await _storage.GetUrlAsync(mediaFile.FtpFilePath);
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