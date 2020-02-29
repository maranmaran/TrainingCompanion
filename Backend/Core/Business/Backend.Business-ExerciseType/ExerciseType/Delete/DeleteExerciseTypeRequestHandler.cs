﻿using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.ExerciseType.ExerciseType.Delete
{
    public class DeleteExerciseTypeRequestHandler : IRequestHandler<DeleteExerciseTypeRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteExerciseTypeRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var exerciseType =
                    await _context.Tags.SingleAsync(x => x.Id == request.Id, cancellationToken);

                _context.Tags.Remove(exerciseType);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(Domain.Entities.ExerciseType.ExerciseType), e);
            }
        }
    }
}