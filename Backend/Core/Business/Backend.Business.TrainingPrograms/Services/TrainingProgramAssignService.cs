using Backend.Business.TrainingPrograms.Interfaces;
using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Domain.Entities.User;
using Backend.Library.Logging.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.Services
{
    internal class TrainingProgramAssignService : ITrainingProgramAssignService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILoggingService _logger;

        public TrainingProgramAssignService(IApplicationDbContext context, ILoggingService logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Assign(TrainingProgram trainingProgram, ApplicationUser user, DateTime startDate, CancellationToken cancellationToken = default)
        {
            try
            {
                // get all training days and go over them in sequence...
                var trainingDays = trainingProgram.TrainingBlocks.OrderBy(x => x.Order).SelectMany(x => x.Days);

                var currentDate = startDate.AddDays(-1);
                foreach (var day in trainingDays)
                {
                    currentDate = currentDate.AddDays(1);

                    // we skip this one
                    if (day.RestDay)
                    {
                        continue;
                    }

                    // add these trainings
                    foreach (var training in day.Trainings)
                    {
                        await AddTraining(training, user, currentDate);
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to assign training program {trainingProgram.Id} to user {user.Id}");
            }
        }

        private async Task AddTraining(Training training, ApplicationUser user, DateTime date)
        {
            var newTraining = new Training
            {
                NoteRead = false,
                Note = training.Note,
                ApplicationUserId = user.Id,
                DateTrained = date,
                Exercises = new List<Exercise>()
            };


            foreach (var exercise in training.Exercises)
            {
                newTraining.Exercises.Add(await AddExercise(exercise, user));
            }

            _context.Trainings.Add(newTraining);
        }

        private async Task<Exercise> AddExercise(Exercise exercise, ApplicationUser user)
        {
            // handle exercise type
            ExerciseType exerciseType = null;
            if (await CheckIfExerciseTypeExists(exercise.ExerciseType, user) == false)
            {
                exerciseType = await AddExerciseType(exercise.ExerciseType, user);
            }
            else
            {
                exerciseType = await _context.ExerciseTypes
                    .Include(x => x.Properties)
                    .ThenInclude(x => x.Tag)
                    .ThenInclude(x => x.TagGroup)
                    .SingleAsync(x => x.Code == exercise.ExerciseType.Code && x.ApplicationUserId == user.Id);

                _context.Entry(exerciseType).State = EntityState.Unchanged;
            }

            var newExercise = new Exercise
            {
                ExerciseType = exerciseType,
                Order = _context.ExerciseTypes.Count(x => x.ApplicationUserId == user.Id) + 1,
                Sets = new List<Set>()
            };

            foreach (var set in exercise.Sets)
            {
                newExercise.Sets.Add(await AddSet(set));
            }


            return newExercise;
        }

        private async Task<Set> AddSet(Set set)
        {
            set.Id = Guid.Empty;
            set.Exercise = null;
            set.ExerciseId = Guid.Empty;

            return set;
        }

        public async Task<bool> CheckIfExerciseTypeExists(ExerciseType exerciseType, ApplicationUser user)
        {
            // find all exerciseTypes with same name and user..
            var types = await _context.ExerciseTypes
                .Include(x => x.Properties)
                .ThenInclude(x => x.Tag)
                .ThenInclude(x => x.TagGroup)
                .Where(x => x.Code == exerciseType.Code && x.ApplicationUserId == user.Id)
                .ToListAsync();

            switch (types.Count)
            {
                case 0:
                    return false; // this kind of exercise type doesn't exist
                case 1:
                    return true;
            }

            var exception = new Exception("Duplicate exercise types in system");
            await _logger.LogError(exception, "Critical exception - duplicate exercise types in system");
            throw exception;
        }

        private async Task<ExerciseType> AddExerciseType(ExerciseType exerciseType, ApplicationUser user)
        {

            // TODO: business decision - don't sweat TagGroup and Tag ids for athlete and coach..
            // Make athlete share coach data in regards to exercise types and it's props.. coach is master of all
            // Just make sure to query by UserId for reports..

            var newExerciseType = new ExerciseType
            {
                ApplicationUserId = user.Id,
                Code = exerciseType.Code,
                Name = exerciseType.Name,
                RequiresBodyweight = exerciseType.RequiresBodyweight,
                RequiresReps = exerciseType.RequiresReps,
                RequiresSets = exerciseType.RequiresSets,
                RequiresWeight = exerciseType.RequiresWeight,
                RequiresTime = exerciseType.RequiresTime,
                Active = true,
                Properties = exerciseType.Properties
            };

            _context.ExerciseTypes.Add(newExerciseType);

            return newExerciseType;
        }
    }
}
