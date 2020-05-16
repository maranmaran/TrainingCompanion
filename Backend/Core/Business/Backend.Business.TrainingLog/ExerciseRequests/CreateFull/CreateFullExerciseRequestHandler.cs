using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.TrainingLog;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingLog.ExerciseRequests.CreateFull
{
    public class CreateFullExerciseRequestHandler : IRequestHandler<CreateFullExerciseRequest, Exercise>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateFullExerciseRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Exercise> Handle(CreateFullExerciseRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _context.Entry(request.Exercise.ExerciseType).State = EntityState.Unchanged;
                _context.Entry(request.Exercise.Training).State = EntityState.Unchanged;

                await _context.Exercises.AddAsync(request.Exercise, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                var type = await _context
                    .ExerciseTypes
                    .Include(x => x.Properties)
                    .ThenInclude(x => x.Tag)
                    .ThenInclude(x => x.TagGroup)
                    .FirstAsync(x => x.Id == request.Exercise.ExerciseTypeId, cancellationToken);

                request.Exercise.ExerciseType = type;

                return request.Exercise;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Exercise), e);
            }
        }
    }
}