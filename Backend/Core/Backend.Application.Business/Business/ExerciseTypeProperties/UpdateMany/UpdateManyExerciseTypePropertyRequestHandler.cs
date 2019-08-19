using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.ExerciseType;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.ExerciseTypeProperties.UpdateMany
{
    public class UpdateExerciseTypePropertyRequestHandler :
        IRequestHandler<UpdateExerciseTypePropertyRequest, IEnumerable<ExerciseTypeProperty>>
    {
        private readonly IApplicationDbContext _context;

        public UpdateExerciseTypePropertyRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExerciseTypeProperty>> Handle(UpdateExerciseTypePropertyRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var updatedProperties = new List<ExerciseTypeProperty>();

                foreach (var requestExerciseTypeProperty in request.ExerciseTypeProperties)
                {
                    var property = await _context.ExerciseTypeProperties.SingleAsync(x => x.Id == requestExerciseTypeProperty.Id, cancellationToken);

                    property.Value = requestExerciseTypeProperty.Value;
                    property.Order = requestExerciseTypeProperty.Order;
                    property.Active = requestExerciseTypeProperty.Active;

                    _context.ExerciseTypeProperties.Update(property);

                    updatedProperties.Add(property);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return updatedProperties;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(ExerciseTypeProperty), e);
            }
        }
    }
}