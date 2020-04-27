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
                var modifiedEntity = _mapper.Map<ExerciseType>(request.ExerciseType);
                var existingEntity = _context.ExerciseTypes.Include(x => x.Properties).First(x => x.Id == request.ExerciseType.Id);

                ClearTagRelations(existingEntity, modifiedEntity);
                var entityToUpdate = _mapper.Map(modifiedEntity, existingEntity);

                _context.ExerciseTypes.Update(entityToUpdate);

                await _context.SaveChangesAsync(cancellationToken);

                return request.ExerciseType;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(ExerciseType), e);
            }
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