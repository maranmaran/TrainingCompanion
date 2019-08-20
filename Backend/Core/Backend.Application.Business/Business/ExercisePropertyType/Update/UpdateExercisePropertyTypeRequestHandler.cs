using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace Backend.Application.Business.Business.ExerciseProperty.UpdateMany
{
    public class UpdateExercisePropertyTypeRequestHandler :
        IRequestHandler<UpdateExercisePropertyTypeRequest, Domain.Entities.ExerciseType.ExercisePropertyType>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateExercisePropertyTypeRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.ExerciseType.ExercisePropertyType> Handle(UpdateExercisePropertyTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var propertyTypeToUpdate = await _context.ExercisePropertyTypes.SingleAsync(x => x.Id == request.Id, cancellationToken);

                _mapper.Map(request, propertyTypeToUpdate);

                _context.ExercisePropertyTypes.Update(propertyTypeToUpdate);

                await _context.SaveChangesAsync(cancellationToken);

                return propertyTypeToUpdate;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.ExerciseProperty), e);
            }
        }
    }
}