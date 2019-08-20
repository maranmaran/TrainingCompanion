using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.ExerciseProperty.UpdateMany
{
    public class UpdateManyExercisePropertyRequestHandler : IRequestHandler<UpdateManyExercisePropertyRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateManyExercisePropertyRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateManyExercisePropertyRequest request, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var requestExerciseProperty in request.ExerciseProperties)
                {
                    _context.ExerciseProperties.Update(requestExerciseProperty);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.ExerciseProperty), e);
            }
        }
    }
}