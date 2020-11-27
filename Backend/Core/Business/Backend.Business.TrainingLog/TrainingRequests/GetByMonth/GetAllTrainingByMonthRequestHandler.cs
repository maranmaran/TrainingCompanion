﻿using Backend.Domain;
using Backend.Domain.Entities.TrainingLog;
using Backend.Infrastructure.Exceptions;
using Backend.Library.AmazonS3.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingLog.TrainingRequests.GetByMonth
{
    public class GetAllTrainingByMonthRequestHandler : IRequestHandler<GetAllTrainingsByMonthRequest, IEnumerable<Training>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IS3Service _s3;

        public GetAllTrainingByMonthRequestHandler(IApplicationDbContext context, IS3Service s3)
        {
            _context = context;
            _s3 = s3;
        }

        public async Task<IEnumerable<Training>> Handle(GetAllTrainingsByMonthRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var trainings = await _context.Trainings
                    .Where(x => x.ApplicationUserId == request.ApplicationUserId &&
                                x.DateTrained.Month == request.Month &&
                                x.DateTrained.Year == request.Year)
                    .OrderBy(x => x.DateTrained)
                    .ToListAsync(cancellationToken);

                return trainings;
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Training), $"Could not find training for {request.ApplicationUserId} USER", e);
            }
        }
    }
}