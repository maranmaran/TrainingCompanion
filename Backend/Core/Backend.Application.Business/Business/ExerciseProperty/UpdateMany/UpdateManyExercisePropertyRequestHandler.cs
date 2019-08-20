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
    public class UpdateExercisePropertyRequestHandler :
        IRequestHandler<UpdateExercisePropertyRequest, IEnumerable<Domain.Entities.ExerciseType.ExerciseProperty>>
    {
        private readonly IApplicationDbContext _context;

        public UpdateExercisePropertyRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.ExerciseType.ExerciseProperty>> Handle(UpdateExercisePropertyRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var updatedProperties = new List<Domain.Entities.ExerciseType.ExerciseProperty>();

                foreach (var requestExerciseProperty in request.ExerciseProperties)
                {
                    var property = await _context.ExerciseProperties.SingleAsync(x => x.Id == requestExerciseProperty.Id, cancellationToken);

                    property.Value = requestExerciseProperty.Value;
                    property.Order = requestExerciseProperty.Order;
                    property.Active = requestExerciseProperty.Active;

                    _context.ExerciseProperties.Update(property);

                    updatedProperties.Add(property);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return updatedProperties;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.ExerciseProperty), e);
            }
        }
    }
}