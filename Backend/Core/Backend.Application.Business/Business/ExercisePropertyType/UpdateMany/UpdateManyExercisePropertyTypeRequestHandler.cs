using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.ExerciseProperty.UpdateMany
{
    public class UpdateManyExercisePropertyTypeRequestHandler :
        IRequestHandler<UpdateManyExercisePropertyTypeRequest, IEnumerable<Domain.Entities.ExerciseType.ExercisePropertyType>>
    {
        private readonly IApplicationDbContext _context;

        public UpdateManyExercisePropertyTypeRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.ExerciseType.ExercisePropertyType>> Handle(UpdateManyExercisePropertyTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var updatedPropertyTypes = new List<Domain.Entities.ExerciseType.ExercisePropertyType>();

                foreach (var requestExerciseProperty in request.ExercisePropertyTypes)
                {
                    var propertyTypeToUpdate = await _context.ExercisePropertyTypes.SingleAsync(x => x.Id == requestExerciseProperty.Id, cancellationToken);

                    propertyTypeToUpdate = requestExerciseProperty;

                    _context.ExercisePropertyTypes.Update(propertyTypeToUpdate);

                    updatedPropertyTypes.Add(propertyTypeToUpdate);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return updatedPropertyTypes;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.ExerciseProperty), e);
            }
        }
    }
}