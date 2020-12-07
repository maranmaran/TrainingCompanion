using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.TrainingLog;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingLog.ExerciseRequests.UpdateFull
{
    public class UpdateFullExerciseRequestHandler : IRequestHandler<UpdateFullExerciseRequest, Exercise>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateFullExerciseRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Exercise> Handle(UpdateFullExerciseRequest request, CancellationToken cancellationToken)
        {
            try
            {

                // existing exercise.. otherwise it's quick add mode.
                if (request.Exercise.ExerciseTypeId != Guid.Empty)
                {
                    _context.Entry(request.Exercise.ExerciseType).State = EntityState.Unchanged;
                }
                //_context.Entry(request.Exercise.Training).State = EntityState.Unchanged;

                _context.Exercises.Update(request.Exercise);
                await _context.SaveChangesAsync(cancellationToken);

                return request.Exercise;
            }
            catch (Exception e)
            {
                throw new UpdateFailureException(nameof(Exercise), e);
            }
        }
    }
}