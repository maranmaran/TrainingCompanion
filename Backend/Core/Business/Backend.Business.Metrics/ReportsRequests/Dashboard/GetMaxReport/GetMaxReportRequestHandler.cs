﻿using Backend.Business.Reports.Models;
using Backend.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Reports.ReportsRequests.Dashboard.GetMaxReport
{
    public class GetMaxReportRequestHandler : IRequestHandler<GetMaxReportRequest, ChartData<double, DateTime>>
    {
        private readonly IApplicationDbContext _context;

        public GetMaxReportRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ChartData<double, DateTime>> Handle(GetMaxReportRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // retrieve user setting to cast to
                var unitSystem = (await _context.UserSettings.FirstOrDefaultAsync(x => x.ApplicationUserId == request.UserId, cancellationToken))?.UnitSystem;

                if (!unitSystem.HasValue)
                    throw new ArgumentException($"No records with user id of {request.UserId}");

                var allDates = new List<DateTime>();
                var dataSets = new List<ChartDataSet<double>>();
                foreach (var exerciseTypeId in request.ExerciseTypeIds)
                {
                    // get relevant trainings (for user, in between dates and that has at least one exercise of wanted type)
                    var trainings = await _context.Trainings
                        .Include(x => x.Exercises)
                        .ThenInclude(x => x.Sets)
                        .Where(x => x.ApplicationUserId == request.UserId &&
                                    x.DateTrained.Date >= request.DateFrom.Date &&
                                    x.DateTrained.Date <= request.DateTo.Date &&
                                    x.Exercises.Any(y => y.ExerciseTypeId == exerciseTypeId))
                        .ToListAsync(cancellationToken);

                    var dates = new List<DateTime>();
                    var data = new List<double>();
                    foreach (var training in trainings)
                    {
                        var exercises = training.Exercises.Where(x => x.ExerciseTypeId == exerciseTypeId);
                        var sets = exercises.SelectMany(x => x.Sets);

                        var date = training.DateTrained;
                        var max = sets.Max(x => x.ProjectedMax).FromMetricTo(unitSystem.Value); // get

                        dates.Add(date);
                        data.Add(max);
                    }

                    allDates.AddRange(dates);
                    dataSets.Add(new ChartDataSet<double>()
                    {
                        Data = data
                    });
                }

                return new ChartData<double, DateTime>
                {
                    Labels = allDates,
                    DataSets = dataSets
                };
            }
            catch (Exception e)
            {
                throw new Exception(nameof(GetMaxReportRequest), e);
            }
        }
    }
}