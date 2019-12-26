﻿using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Training.GetByWeek
{
    public class GetAllTrainingByWeekRequestHandler : IRequestHandler<GetAllTrainingsByWeekRequest, IQueryable<Domain.Entities.TrainingLog.Training>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTrainingByWeekRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Domain.Entities.TrainingLog.Training>> Handle(GetAllTrainingsByWeekRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var trainings = _context.Trainings.Where(x => x.ApplicationUserId == request.ApplicationUserId &&
                                                              x.DateTrained >= request.WeekStart &&
                                                              x.DateTrained <= request.WeekEnd);

                return Task.FromResult(trainings);
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.TrainingLog.Training), $"Could not find training for {request.ApplicationUserId} USER", e);
            }
        }
    }
}