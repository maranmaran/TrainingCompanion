using Backend.Business.Reports.Models;
using Backend.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Reports.ReportsRequests.Dashboard.GetVolumeWithAvgIntensityReport
{
    public class GetVolumeWithAvgIntensityReportRequestHandler : IRequestHandler<GetVolumeWithAvgIntensityReportRequest, ChartData<double, DateTime>>
    {
        private readonly IApplicationDbContext _context;

        public GetVolumeWithAvgIntensityReportRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ChartData<double, DateTime>> Handle(GetVolumeWithAvgIntensityReportRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // retrieve user setting to cast to
                var unitSystem = (await _context.UserSettings.FirstOrDefaultAsync(x => x.ApplicationUserId == request.UserId, cancellationToken))?.UnitSystem;

                if (!unitSystem.HasValue)
                    throw new ArgumentException($"No records with user id of {request.UserId}");

                // get relevant trainings (for user, in between dates and that has at least one exercise of wanted type)
                var trainings = await _context.Trainings
                    .Include(x => x.Exercises)
                    .ThenInclude(x => x.Sets)
                    .Where(x => x.ApplicationUserId == request.UserId &&
                                x.DateTrained.Date >= request.DateFrom.Date &&
                                x.DateTrained.Date <= request.DateTo.Date &&
                                x.Exercises.Any(y => y.ExerciseTypeId == request.ExerciseTypeId))
                    .ToListAsync(cancellationToken);

                var databaseMax = (await _context.PBs
                        .OrderByDescending(x => x.DateAchieved)
                        .FirstOrDefaultAsync(x => x.ExerciseTypeId == request.ExerciseTypeId, cancellationToken))
                    ?.Value.FromMetricTo(unitSystem.Value) ?? 0;

                var dates = new List<DateTime>();
                var volumeData = new List<double>();
                var avgIntensityData = new List<double>();
                foreach (var training in trainings)
                {
                    var exercises = training.Exercises.Where(x => x.ExerciseTypeId == request.ExerciseTypeId);
                    var sets = exercises.SelectMany(x => x.Sets).ToList();

                    // date
                    var date = training.DateTrained;
                    dates.Add(date);

                    // volume
                    var volume = sets.Sum(x => x.Volume).FromMetricTo(unitSystem.Value); // get
                    volumeData.Add(volume);

                    // get max
                    var max = databaseMax;
                    if (Math.Abs(max) < double.Epsilon) // comparison of double with zero
                    {
                        max = sets.Max(x => x.ProjectedMax);
                    }

                    // get avg intensity
                    var avgIntensity = sets.Aggregate(0d, (i, set) =>
                    {
                        if (Math.Abs(max) < double.Epsilon) // comparison of double with zero
                            return 0;

                        var setWeight = set.Weight.FromMetricTo(unitSystem.Value);
                        return i + setWeight / max * 100;
                    }) / sets.Count();

                    avgIntensityData.Add(avgIntensity);
                }

                return new ChartData<double, DateTime>
                {
                    Labels = dates,
                    DataSets = new List<ChartDataSet<double>>
                    {
                        new ChartDataSet<double>
                        {
                            Data = volumeData
                        },
                        new ChartDataSet<double>
                        {
                            Data = avgIntensityData
                        }
                    }
                };
            }
            catch (Exception e)
            {
                throw new Exception(nameof(GetVolumeWithAvgIntensityReportRequest), e);
            }
        }
    }
}