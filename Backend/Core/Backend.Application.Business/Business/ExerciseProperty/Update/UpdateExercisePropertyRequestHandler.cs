using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.ExerciseProperty.Update
{
    public class UpdateExercisePropertyRequestHandler :
        IRequestHandler<UpdateExercisePropertyRequest, Domain.Entities.ExerciseType.ExerciseProperty>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateExercisePropertyRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.ExerciseType.ExerciseProperty> Handle(UpdateExercisePropertyRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var propertyToUpdate = await _context.ExerciseProperties.SingleAsync(x => x.Id == request.Id, cancellationToken);

                _mapper.Map(request, propertyToUpdate);

                _context.ExerciseProperties.Update(propertyToUpdate);

                await _context.SaveChangesAsync(cancellationToken);

                return propertyToUpdate;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.ExerciseProperty), e);
            }
        }
    }
}