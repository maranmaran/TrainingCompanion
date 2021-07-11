using Backend.Business.Reports.Models;
using Backend.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Reports.ReportsRequests.Dashboard.GetBaselineVolumeWithRelativeIntensityReport
{
    public class GetBaselineVolumeWithRelativeIntensityReportRequestHandler : IRequestHandler<GetBaselineVolumeWithRelativeIntensityReportRequest, ChartData<double, DateTime>>
    {
        private readonly IApplicationDbContext _context;

        public GetBaselineVolumeWithRelativeIntensityReportRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ChartData<double, DateTime>> Handle(GetBaselineVolumeWithRelativeIntensityReportRequest request, CancellationToken cancellationToken)
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
                var baselineVolumeData = new List<double>();
                var relativeIntensityData = new List<double>();
                foreach (var training in trainings)
                {
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(GetBaselineVolumeWithRelativeIntensityReportRequest), e);
            }
        }
    }
}