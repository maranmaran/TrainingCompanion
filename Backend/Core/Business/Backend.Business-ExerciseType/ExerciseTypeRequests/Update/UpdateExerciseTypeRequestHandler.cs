using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Exercises.ExerciseTypeRequests.Update
{
    public class UpdateExerciseTypeRequestHandler :
        IRequestHandler<UpdateExerciseTypeRequest, ExerciseType>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateExerciseTypeRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExerciseType> Handle(UpdateExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entityToUpdate = _context.ExerciseTypes.Include(x => x.Properties).First(x => x.Id == request.ExerciseType.Id);
                var user = await _context.Coaches.Include(x => x.Athletes).FirstOrDefaultAsync(x => x.Id == entityToUpdate.ApplicationUserId, cancellationToken);

                Update(entityToUpdate, request.ExerciseType);

                // athlete needs to have the same record
                if (user != null)
                {
                    foreach (var athlete in user.Athletes)
                    {
                        var athleteExerciseType = await _context.ExerciseTypes
                            .FirstOrDefaultAsync(x => x.Code == entityToUpdate.Code &&
                                                      x.ApplicationUserId == athlete.Id, cancellationToken);

                        Update(athleteExerciseType, request.ExerciseType);
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);

                return request.ExerciseType;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(ExerciseType), e);
            }
        }

        public void Update(ExerciseType existing, ExerciseType modified)
        {
            var userId = existing.ApplicationUserId;
            var id = existing.Id;

            ClearTagRelations(existing, modified);
            var entityToUpdate = _mapper.Map(modified, existing);

            entityToUpdate.ApplicationUserId = userId;
            entityToUpdate.Id = id;

            _context.ExerciseTypes.Update(entityToUpdate);
        }

        public void ClearTagRelations(ExerciseType exerciseType, ExerciseType updatedExerciseType)
        {
            // delete property relations
            foreach (var prop in exerciseType.Properties)
            {
                if (updatedExerciseType.Properties.All(x => x.Id != prop.Id))
                {
                    _context.Entry(prop).State = EntityState.Deleted;
                }
            }
        }
    }
}