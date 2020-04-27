using Backend.Business.TrainingPrograms.Interfaces;
using Backend.Domain;
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
                await AssignTrainingProgramToUser(trainingProgram.Id, user.Id, startDate);
                await ImportTrainingDataToCalendar(trainingProgram, user, startDate);

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to assign training program {trainingProgram.Id} to user {user.Id}");
            }
        }

        private async Task AssignTrainingProgramToUser(Guid trainingProgramId, Guid userId, DateTime startDate)
        {
            var trainingProgramUser = new TrainingProgramUser()
            {
                ApplicationUserId = userId,
                StartedOn = startDate.ToUniversalTime(),
                TrainingProgramId = trainingProgramId,
            };

            await _context.TrainingProgramUsers.AddAsync(trainingProgramUser);
        }

        private async Task ImportTrainingDataToCalendar(TrainingProgram trainingProgram, ApplicationUser user, DateTime startDate)
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

            await _context.Trainings.AddAsync(newTraining);
        }

        private async Task<Exercise> AddExercise(Exercise exercise, ApplicationUser user)
        {
            // handle exercise type
            // exercise type certainly exists 
            var exerciseType = await _context.ExerciseTypes
                .Include(x => x.Properties)
                .ThenInclude(x => x.Tag)
                .ThenInclude(x => x.TagGroup)
                .SingleAsync(x => x.Code == exercise.ExerciseType.Code && x.ApplicationUserId == user.Id);
            _context.Entry(exerciseType).State = EntityState.Unchanged;

            var newExercise = new Exercise
            {
                ExerciseType = exerciseType,
                Order = _context.ExerciseTypes.Count(x => x.ApplicationUserId == user.Id) + 1,
                Sets = new List<Set>()
            };

            foreach (var set in exercise.Sets)
            {
                newExercise.Sets.Add(AddSet(set));
            }


            return newExercise;
        }

        private Set AddSet(Set set)
        {
            set.Id = Guid.Empty;
            set.Exercise = null;
            set.ExerciseId = Guid.Empty;

            return set;
        }
    }
}
