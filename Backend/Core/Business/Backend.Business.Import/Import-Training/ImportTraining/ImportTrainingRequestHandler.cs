using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Domain.Entities.TrainingLog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Import.ImportTraining
{
    public class ImportTrainingRequestHandler : IRequestHandler<ImportTrainingRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public ImportTrainingRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ImportTrainingRequest request, CancellationToken cancellationToken)
        {
            try
            {
                //var dataRows = await _excelService.ParseImportData<TrainingImportDto>(request.File, cancellationToken);
                var exerciseTypes = _context.ExerciseTypes.Where(x => x.ApplicationUserId == request.Userid).AsNoTracking();

                //var trainings = ParseImportData(dataRows, exerciseTypes, request.Userid);

                //await _context.Trainings.AddRangeAsync(trainings, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception("Could not import training.", e);
            }
        }

        private IEnumerable<Training> ParseImportData(IEnumerable<TrainingImportDto> data, IEnumerable<ExerciseType> exerciseTypes, Guid userId)
        {
            var trainingDict = new Dictionary<DateTime, IDictionary<string, Exercise>>();

            foreach (var row in data)
            {
                var set = new Set()
                {
                    Reps = row.Reps,
                    Weight = row.Weight,
                    Time = row.Time,
                    Rpe = row.Rpe,
                    Volume = row.Reps * row.Weight
                };

                if (!trainingDict.TryGetValue(row.Date, out var existingTraining))
                {
                    var exerciseType = exerciseTypes.FirstOrDefault(x => x.Code == row.Code);
                    var exercise = new Exercise
                    {
                        ExerciseTypeId = exerciseType.Id,
                        Sets = new List<Set>() { set }
                    };

                    var exerciseDict = new Dictionary<string, Exercise>
                    {
                        { row.Code, exercise }
                    };

                    trainingDict.Add(row.Date, exerciseDict);
                }
                else
                {
                    if (!existingTraining.TryGetValue(row.Code, out var existingExercise))
                    {
                        var exerciseType = exerciseTypes.FirstOrDefault(x => x.Code == row.Code);
                        var exercise = new Exercise
                        {
                            ExerciseType = exerciseType,
                            ExerciseTypeId = exerciseType.Id,
                            Sets = new List<Set>() { set }
                        };

                        existingTraining.Add(row.Code, exercise);
                    }
                    else
                    {
                        existingExercise.Sets.Add(set);
                    }
                }
            }

            var trainings = trainingDict.Select(x => new Training()
            {
                DateTrained = x.Key,
                Exercises = x.Value.Values,
                ApplicationUserId = userId
            });

            return trainings;
        }
    }
}