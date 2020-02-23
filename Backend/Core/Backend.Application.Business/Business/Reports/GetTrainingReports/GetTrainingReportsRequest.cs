﻿using Backend.Application.Business.Code;
using Backend.Domain;
using Backend.Domain.Entities.User;
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
        public ChartData<(double, string)> RelativeZoneOfIntensityChartData { get; set; }
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
                var userSetting = (await _context.Users.Include(x => x.UserSetting).FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken))?.UserSetting;

                if (userSetting == null)
                    return null;

                var exercises = (await _context
                    .Trainings
                    .Include(x => x.Exercises).ThenInclude(x => x.ExerciseType).ThenInclude(x => x.ExerciseMaxes)
                    .Include(x => x.Exercises).ThenInclude(x => x.Sets)
                    .Where(x => x.Id == request.TrainingId)
                    .FirstOrDefaultAsync(cancellationToken))?.Exercises.ToList();

                if (exercises == null)
                    return null;

                #region COmment
                //var exerciseLabels = new List<string>();

                //var numberOfLiftsData = new List<double>();
                //var totalVolumeData = new List<double>();

                //var averageIntensity = new List<double>();
                //var peakIntensity = new List<double>();

                //var averageInolData = new List<double>();  // weighted average intensity SETS x (REPS / (100-Intensity)) = iNoL quotient
                //var relativeZoneOfIntensityData = new List<string>();

                //foreach (var exercise in trainingExercises)
                //{
                //    exerciseLabels.Add(exercise.ExerciseType.Name);

                //    double volumeCount = 0;
                //    double repsCount = 0;
                //    double setCount = 0;
                //    double inolSum = 0;
                //    double strengthZoneCount = 0;
                //    double sizeZoneCount = 0;
                //    double enduranceZoneCount = 0;
                //    double intensitySum = 0;
                //    double maxIntensity = Double.MinValue;


                //    foreach (var set in exercise.Sets)
                //    {
                //        volumeCount += set.Volume.TransformWeight(userSetting.UnitSystem);
                //        repsCount += set.Reps;
                //        setCount++;

                //        var max = exercise.ExerciseType.ExerciseMaxes.OrderByDescending(x => x.DateAchieved).FirstOrDefault()?.Max ?? set.ProjectedMax;
                //        var intensity = set.Weight.TransformWeight(userSetting.UnitSystem) / max.TransformWeight(userSetting.UnitSystem);

                //        intensitySum += intensity * 100;
                //        if (maxIntensity < intensity)
                //            maxIntensity = intensity * 100;

                //        if (intensity <= 1)
                //        {
                //            inolSum += set.Reps / (100 - intensity * 100);
                //        }

                //        if (intensity > 0.75)
                //        {
                //            strengthZoneCount++;
                //        }
                //        else if (intensity > 0.5)
                //        {
                //            sizeZoneCount++;
                //        }
                //        else
                //        {
                //            enduranceZoneCount++;
                //        }
                //    }
                //    numberOfLiftsData.Add(repsCount);
                //    totalVolumeData.Add(Math.Round(volumeCount, 2));

                //    averageIntensity.Add(Math.Round(intensitySum / setCount, 2));
                //    peakIntensity.Add(Math.Round(maxIntensity, 2));

                //    averageInolData.Add(Math.Round(inolSum / setCount, 2));

                //    var zonePercentages = new (double Percentage, string Zone)[]
                //    {
                //        (strengthZoneCount / setCount, "strength"),
                //        (sizeZoneCount / setCount, "size"),
                //        (enduranceZoneCount / setCount, "endurance")
                //    };

                //    var relativeZone = zonePercentages.Aggregate((i1, i2) => i1.Percentage > i2.Percentage ? i1 : i2).Zone;

                //    relativeZoneOfIntensityData.Add(relativeZone);
                //}

                //var volumeSplitData = totalVolumeData.Select(data => Math.Round(data / totalVolumeData.Sum() * 100));

                #endregion

                var exerciseLabels = GetExerciseLabels(exercises).ToList();
                var numberOfLiftsData = GetNumberOfLiftsData(exercises);
                var volumeData = GetVolumeData(exercises, userSetting);
                var intensityData = GetIntensityData(exercises, userSetting);

                var response = new GetTrainingReportsResponse
                {
                    NumberOfLiftsChartData = new ChartData<double>()
                    {
                        Labels = exerciseLabels,
                        DataSets = new List<ChartDataSet<double>>()
                            {
                                new ChartDataSet<double>() {Data = numberOfLiftsData}
                            }
                    },
                    RelativeZoneOfIntensityChartData = new ChartData<(double, string)>()
                    {
                        Labels = exerciseLabels,
                        DataSets = new List<ChartDataSet<(double, string)>>()
                            {
                                new ChartDataSet<(double, string)>() {Data = intensityData.ZoneOfIntensity}
                            }
                    },
                    TotalVolumeChartData = new ChartData<double>()
                    {
                        Labels = exerciseLabels,
                        DataSets = new List<ChartDataSet<double>>()
                            {
                                new ChartDataSet<double>() {Data = volumeData.Total},
                                new ChartDataSet<double>() {Data = intensityData.Average},
                                new ChartDataSet<double>() {Data = intensityData.Peak}
                            }
                    },
                    VolumeSplitChartData = new ChartData<double>()
                    {
                        Labels = exerciseLabels,
                        DataSets = new List<ChartDataSet<double>>()
                            {
                                new ChartDataSet<double>() {Data = volumeData.VolumeSplit}
                            }
                    },
                };

                return response;
            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(GetTrainingReportsRequest), e);
            }
        }

        private IEnumerable<string> GetExerciseLabels(List<Domain.Entities.TrainingLog.Exercise> exercises)
        {
            return exercises.Select(x => x.ExerciseType.Name);
        }

        private IEnumerable<double> GetNumberOfLiftsData(List<Domain.Entities.TrainingLog.Exercise> exercises)
        {
            return exercises.Select(x => x.Sets.Sum(y => y.Reps));
        }

        private (IEnumerable<double> Total, IEnumerable<double> VolumeSplit) GetVolumeData(List<Domain.Entities.TrainingLog.Exercise> exercises, UserSetting userSetting)
        {
            var totalVolume = exercises.Sum(x => x.Sets.Sum(x => x.Volume.TransformWeight(userSetting.UnitSystem)));

            var totalExerciseVolume = exercises.Select(x =>
            {
                double Transform(double volume) => volume.TransformWeight(userSetting.UnitSystem);
                double VolumeSum(Domain.Entities.TrainingLog.Set set) => Transform(set.Volume);

                var totalVolume = x.Sets.Sum(VolumeSum);

                return Math.Round(totalVolume, 2);
            }).ToList();


            return (totalExerciseVolume, totalExerciseVolume);
        }

        private (IEnumerable<double> Average, IEnumerable<double> Peak, IEnumerable<(double percentage, string label)> ZoneOfIntensity) GetIntensityData(List<Domain.Entities.TrainingLog.Exercise> exercises, UserSetting userSetting)
        {
            // relative zone of intensity

            // Strength - About 50-75% of your total sets performed within the 75-90% intensity, with some work in the 50-75% intensity. (Training much above 90% intensity is too fatiguing to be practical on a regular basis, training below 75% builds muscle which helps build strength.)

            // Size - About 50 - 75 % of your total sets performed within the 50 - 75 % intensity, with some work heaver or lighter. (Training above helps build strength, training below helps build endurance: both will help increase the amount of volume you can complete within this rep range.)

            // Endurance - About 50 - 75 % of your training performed within the 0 - 50 % intensity(namely, with cardio) with some work heavier. (Heavier work will help improve bone density, connective tissue strength, and body composition, all of which will help endurance athletes improve long term.)

            var averageIntensityData = new List<double>();
            var peakIntensityData = new List<double>();
            var zoneOfIntensity = new List<(double percentage, string label)>();

            foreach (var exercise in exercises)
            {
                var loggedMax = exercise.ExerciseType.ExerciseMaxes.OrderByDescending(x => x.DateAchieved).FirstOrDefault()?.Max;
               
                var totalSets = 0;
                var totalIntensity = 0.0;
                var peakIntensity = 0.0;
                var relativeZoneCount = (Strength: 0, Size: 0, Endurance: 0);


                foreach (var set in exercise.Sets)
                {
                    var max = loggedMax ?? set.ProjectedMax;
                    var intensity = max > 0 ? (set.Weight.TransformWeight(userSetting.UnitSystem) / max.TransformWeight(userSetting.UnitSystem)) * 100 : 0;
                    totalIntensity += intensity;
                    totalSets++;

                    if (intensity > peakIntensity)
                        peakIntensity = intensity;


                    if (intensity > 0.75)
                    {
                        relativeZoneCount.Strength++;
                    }
                    else if (intensity > 0.5)
                    {
                        relativeZoneCount.Size++;
                    }
                    else
                    {
                        relativeZoneCount.Endurance++;
                    }
                }

                peakIntensityData.Add(Math.Round(peakIntensity, 2));
                averageIntensityData.Add(Math.Round(totalIntensity / totalSets, 2));

                var strengthPercentage = Math.Round((double)relativeZoneCount.Strength / totalSets, 2);
                var sizePercentage = Math.Round((double)relativeZoneCount.Size / totalSets, 2);
                var endurancePercentage = Math.Round((double)relativeZoneCount.Endurance / totalSets, 2);
                var zonePercentages = new (double Percentage, (double percentage, string label) Zone)[]
                {
                    (strengthPercentage, (strengthPercentage, "strength")),
                    (sizePercentage, (sizePercentage, "size")),
                    (endurancePercentage, (endurancePercentage, "endurance")),
                };
                zoneOfIntensity.Add(zonePercentages.Aggregate((i1, i2) => i1.Percentage > i2.Percentage ? i1 : i2).Zone);
            }

            return (averageIntensityData, peakIntensityData, zoneOfIntensity);
        }

    }

}
