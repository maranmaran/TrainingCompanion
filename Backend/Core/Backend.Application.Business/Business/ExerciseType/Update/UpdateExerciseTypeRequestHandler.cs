using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.ExerciseType.Update
{
    public class UpdateExerciseTypeRequestHandler :
        IRequestHandler<UpdateExerciseTypeRequest, Domain.Entities.ExerciseType.ExerciseType>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateExerciseTypeRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.ExerciseType.ExerciseType> Handle(UpdateExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entityToUpdate = _context.ExerciseTypes.Single(x => x.Id == request.Id);

                _mapper.Map(request, entityToUpdate);

                _context.ExerciseTypes.Update(entityToUpdate);
                await _context.SaveChangesAsync(cancellationToken);

                return entityToUpdate;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.ExerciseType), e);
            }
        }
    }
}