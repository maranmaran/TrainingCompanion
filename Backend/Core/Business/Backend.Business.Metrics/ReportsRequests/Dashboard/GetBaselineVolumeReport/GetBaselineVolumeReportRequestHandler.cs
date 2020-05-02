using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Business.Reports.Models;
using Backend.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Reports.ReportsRequests.Dashboard.GetBaselineVolumeReport
{
    public class GetBaselineVolumeReportRequestHandler : IRequestHandler<GetBaselineVolumeReportRequest, ChartData<double, DateTime>>
    {
        private readonly IApplicationDbContext _context;

        public GetBaselineVolumeReportRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ChartData<double, DateTime>> Handle(GetBaselineVolumeReportRequest request, CancellationToken cancellationToken)
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
                    .Where(x => x.ApplicationUserId == request.UserId &&
                                x.DateTrained.Date >= request.DateFrom.Date &&
                                x.DateTrained.Date <= request.DateTo.Date &&
                                x.Exercises.Any(y => y.ExerciseTypeId == request.ExerciseTypeId))
                    .ToListAsync(cancellationToken);

                var dates = new List<DateTime>();
                var data = new List<double>();
                foreach (var training in trainings)
                {
                    dates.Add(training.DateTrained);

                    var exercises = training.Exercises.Where(x => x.ExerciseTypeId == request.ExerciseTypeId);
                    var sets = exercises.SelectMany(x => x.Sets);

                    // get baseline stuff
                }

                return new ChartData<double, DateTime>
                {
                    Labels = dates,
                    DataSets = new List<ChartDataSet<double>>
                    {
                        new ChartDataSet<double>
                        {
                            Data = data
                        }
                    }
                };
            }
            catch (Exception e)
            {
                throw new Exception(nameof(GetBaselineVolumeReportRequest), e);
            }
        }
    }
}