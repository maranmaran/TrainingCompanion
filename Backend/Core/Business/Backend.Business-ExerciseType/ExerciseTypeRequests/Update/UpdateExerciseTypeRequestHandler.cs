using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using Backend.Library.Logging.Interfaces;
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
        private readonly ILoggingService _logger;

        public UpdateExerciseTypeRequestHandler(IApplicationDbContext context, IMapper mapper, ILoggingService logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ExerciseType> Handle(UpdateExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = request.ExerciseType.ApplicationUserId;
                var modifiedEntity = _mapper.Map<ExerciseType>(request.ExerciseType);
                var existingEntity = _context.ExerciseTypes.Include(x => x.Properties).First(x => x.Id == request.ExerciseType.Id);

                Update(existingEntity, modifiedEntity);

                // if coach...athlete needs to have the same record
                var user = await _context.Coaches.Include(x => x.Athletes).FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
                if (user != null)
                {
                    foreach (var athlete in user.Athletes)
                    {
                        var existingAthleteEntity = await _context.ExerciseTypes.FirstOrDefaultAsync(x => x.Code == existingEntity.Code && x.ApplicationUserId == athlete.Id, cancellationToken);
                        if (existingAthleteEntity != null)
                        {
                            Update(existingAthleteEntity, modifiedEntity);
                        }
                        else
                        {
                            await _logger.LogWarning($"Missing coach exercise type {modifiedEntity.Id} at athlete {athlete.Id}");
                        }
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
            //var userId = existing.ApplicationUserId;
            //var id = existing.Id;

            ClearTagRelations(existing, modified);
            var entityToUpdate = _mapper.Map(modified, existing);

            //entityToUpdate.ApplicationUserId = userId;
            //entityToUpdate.Id = id;

            _context.ExerciseTypes.Update(entityToUpdate);
        }

        /// Any tag property from modified entity that has been removed must be marked as deleted
        public void ClearTagRelations(ExerciseType existing, ExerciseType modified)
        {
            foreach (var prop in existing.Properties)
            {
                if (modified.Properties.All(x => x.Id != prop.Id))
                {
                    _context.Entry(prop).State = EntityState.Deleted;
                }
            }
        }
    }
}