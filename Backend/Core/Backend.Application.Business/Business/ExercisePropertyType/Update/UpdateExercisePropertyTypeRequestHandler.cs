using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.ExercisePropertyType.Update
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
                _context.ExercisePropertyTypes.Update(request.ExercisePropertyType); // update

                await _context.SaveChangesAsync(cancellationToken);

                return request.ExercisePropertyType;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.ExerciseProperty), e);
            }
        }
    }
}