﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Business.TrainingPrograms.TrainingBlockRequests.Delete;
using Backend.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.TrainingPrograms.TrainingProgramRequests.Delete
{
    public class DeleteTrainingProgramRequestHandler : IRequestHandler<DeleteTrainingBlockRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTrainingProgramRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(DeleteTrainingBlockRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.TrainingPrograms.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                _context.TrainingPrograms.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(DeleteTrainingBlockRequest), e);
            }
        }
    }
}