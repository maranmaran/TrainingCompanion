using Backend.Application.Business.Code;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Reports.GetTrainingReports
{
    public class GetTrainingReportsRequest : IRequest<GetTrainingReportsResponse>
    {
        public Guid TrainingId { get; set; }
        public Guid UserId { get; set; }
    }

    public class GetTrainingReportsResponse
    {
        public GetTrainingReportsResponse()
        {
        }

        public ChartData<double> TotalVolumeChartData { get; set; }
        public ChartData<double> VolumeSplitChartData { get; set; }
        public ChartData<double> WeightedAverageIntensityChartData { get; set; }
        public ChartData<double> NumberOfLiftsChartData { get; set; }
        public ChartData<string> RelativeZoneOfIntensityChartData { get; set; }
    }

    public class ChartDataSet<T>
    {
        public ChartDataSet()
        {
            Data = new List<T>();
        }

        public IEnumerable<T> Data { get; set; }
    }

    public class ChartData<T>
    {
        public IEnumerable<string> Labels { get; set; }
        public IEnumerable<ChartDataSet<T>> DataSets { get; set; }
    }


    public class GetTrainingReportsRequestHandler : IRequestHandler<GetTrainingReportsRequest, GetTrainingReportsResponse>
    {
        private readonly IApplicationDbContext _context;

        public GetTrainingReportsRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetTrainingReportsResponse> Handle(GetTrainingReportsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.Include(x => x.UserSetting).FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

                var training = await _context
                    .Trainings
                    .Include(x => x.Exercises).ThenInclude(x => x.ExerciseType).ThenInclude(x => x.ExerciseMaxes)
                    .Include(x => x.Exercises).ThenInclude(x => x.Sets)
                    .Where(x => x.Id == request.TrainingId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (training == null)
                    return null;

                var response = new GetTrainingReportsResponse();

                var numberOfLiftsData = new List<double>();
                var exerciseLabels = new List<string>();
                var totalVolumeData = new List<double>();
                var averageIntensity = new List<double>();
                var peakIntensity = new List<double>();

                var averageInolData = new List<double>();  // weighted average intensity SETS x (REPS / (100-Intensity)) = iNoL quotient
                var relativeZoneOfIntensityData = new List<string>();

                foreach (var exercise in training.Exercises)
                {
                    exerciseLabels.Add(exercise.ExerciseType.Name);

                    double volumeCount = 0;
                    double repsCount = 0;
                    double setCount = 0;
                    double inolSum = 0;
                    double strengthZoneCount = 0;
                    double sizeZoneCount = 0;
                    double enduranceZoneCount = 0;
                    double intensitySum = 0;
                    double maxIntensity = Double.MinValue;


                    foreach (var set in exercise.Sets)
                    {
                        volumeCount += set.Volume.TransformWeight(user.UserSetting.UnitSystem);
                        repsCount += set.Reps;
                        setCount++;

                        var max = exercise.ExerciseType.ExerciseMaxes.OrderByDescending(x => x.DateAchieved).FirstOrDefault()?.Max ?? set.ProjectedMax;
                        var intensity = set.Weight.TransformWeight(user.UserSetting.UnitSystem) / max.TransformWeight(user.UserSetting.UnitSystem);

                        intensitySum += Math.Round(intensity * 100);
                        if (maxIntensity < intensity)
                            maxIntensity = Math.Round(intensity * 100);

                        if (intensity <= 1)
                        {
                            inolSum += set.Reps / (100 - intensity * 100);
                        }

                        if (intensity > 0.75)
                        {
                            strengthZoneCount++;
                        }
                        else if (intensity > 0.5)
                        {
                            sizeZoneCount++;
                        }
                        else
                        {
                            enduranceZoneCount++;
                        }
                    }

                    averageIntensity.Add(intensitySum / setCount);
                    peakIntensity.Add(maxIntensity);

                    var zonePercentages = new (double Percentage, string Zone)[]
                    {
                        (strengthZoneCount / setCount, "strength"),
                        (sizeZoneCount / setCount, "size"),
                        (enduranceZoneCount / setCount, "endurance")
                    };


                    var relativeZone = zonePercentages.Aggregate((i1, i2) => i1.Percentage > i2.Percentage ? i1 : i2).Zone;

                    relativeZoneOfIntensityData.Add(relativeZone);
                    averageInolData.Add(Math.Round(inolSum / setCount, 2));
                    numberOfLiftsData.Add(repsCount);
                    totalVolumeData.Add(Math.Round(volumeCount, 2));
                }

                var volumeSplitData = totalVolumeData.Select(data => Math.Round(data / totalVolumeData.Sum() * 100));

                // relative zone of intensity

                // Strength - About 50-75% of your total sets performed within the 75-90% intensity, with some work in the 50-75% intensity. (Training much above 90% intensity is too fatiguing to be practical on a regular basis, training below 75% builds muscle which helps build strength.)

                // Size - About 50 - 75 % of your total sets performed within the 50 - 75 % intensity, with some work heaver or lighter. (Training above helps build strength, training below helps build endurance: both will help increase the amount of volume you can complete within this rep range.)

                // Endurance - About 50 - 75 % of your training performed within the 0 - 50 % intensity(namely, with cardio) with some work heavier. (Heavier work will help improve bone density, connective tissue strength, and body composition, all of which will help endurance athletes improve long term.)

                response.NumberOfLiftsChartData = new ChartData<double>()
                {
                    Labels = exerciseLabels,
                    DataSets = new List<ChartDataSet<double>>()
                    {
                        new ChartDataSet<double>()
                        {
                            Data = numberOfLiftsData
                        }
                    }
                };

                response.RelativeZoneOfIntensityChartData = new ChartData<string>()
                {
                    Labels = exerciseLabels,
                    DataSets = new List<ChartDataSet<string>>()
                    {
                        new ChartDataSet<string>()
                        {
                            Data = relativeZoneOfIntensityData
                        }
                    }
                };

                response.TotalVolumeChartData = new ChartData<double>()
                {
                    Labels = exerciseLabels,
                    DataSets = new List<ChartDataSet<double>>()
                    {
                        new ChartDataSet<double>()
                        {
                            Data = totalVolumeData
                        },
                        new ChartDataSet<double>()
                        {
                            Data = averageIntensity
                        },
                        new ChartDataSet<double>()
                        {
                            Data = peakIntensity
                        }
                    }
                };

                response.VolumeSplitChartData = new ChartData<double>()
                {
                    Labels = exerciseLabels,
                    DataSets = new List<ChartDataSet<double>>()
                    {
                        new ChartDataSet<double>()
                        {
                            Data = volumeSplitData
                        }
                    }
                };

                response.WeightedAverageIntensityChartData = new ChartData<double>()
                {
                    Labels = exerciseLabels,
                    DataSets = new List<ChartDataSet<double>>()
                    {
                        new ChartDataSet<double>()
                        {
                            Data = averageInolData
                        }
                    }
                };


                return response;
            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(GetTrainingReportsRequest), e);
            }
        }

    }

}
