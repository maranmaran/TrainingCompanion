using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Exercise.Create
{
    public class CreateExerciseRequestHandler :
        IRequestHandler<CreateExerciseRequest, Domain.Entities.TrainingLog.Exercise>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateExerciseRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.TrainingLog.Exercise> Handle(CreateExerciseRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newExercise = _mapper.Map<Domain.Entities.TrainingLog.Exercise>(request);

                await _context.Exercises.AddAsync(newExercise, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                var type = await _context
                    .ExerciseTypes
                    .Include(x => x.Properties)
                    .ThenInclude(x => x.Tag)
                    .ThenInclude(x => x.TagGroup)
                    .FirstAsync(x => x.Id == newExercise.ExerciseTypeId, cancellationToken);

                newExercise.ExerciseType = type;

                return newExercise;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.TrainingLog.Exercise), e);
            }
        }
    }
}