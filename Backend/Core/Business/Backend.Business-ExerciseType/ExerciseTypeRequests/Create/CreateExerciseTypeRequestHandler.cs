using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Exercises.ExerciseTypeRequests.Create
{
    public class CreateExerciseTypeRequestHandler :
        IRequestHandler<CreateExerciseTypeRequest, ExerciseType>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateExerciseTypeRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExerciseType> Handle(CreateExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entityToCreate = _mapper.Map<ExerciseType>(request);

                await _context.ExerciseTypes.AddAsync(entityToCreate, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                // load tags for display
                foreach (var prop in entityToCreate.Properties)
                {
                    // tag must be loaded.. so we can access parent tag group
                    await _context.Entry(prop).Reference(x => x.Tag).LoadAsync(cancellationToken);
                    await _context.Entry(prop.Tag).Reference(x => x.TagGroup).LoadAsync(cancellationToken);
                }

                return entityToCreate;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(ExerciseType), e);
            }
        }
    }
}