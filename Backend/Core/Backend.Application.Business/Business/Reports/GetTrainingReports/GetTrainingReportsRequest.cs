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
        public Guid Id { get; set; }
    }

    // total volume
    // volume split
    // weighted average intensity
    // number of lifts
    // relative zone of intensity
    public class GetTrainingReportsResponse
    {
        public ChartData<double> TotalVolumeChartData { get; set; }
        public ChartData<double> VolumeSplitChartData { get; set; }
        public ChartData<double> WeightedAverageIntensityChartData { get; set; }
        public ChartData<double> NumberOfLiftsChartData { get; set; }
        public ChartData<double> RelativeZoneOfIntensityChartData { get; set; }
    }

    public class ChartData<T>
    {
        public class ChartDataSet<T>
        {
            public IEnumerable<T> Data { get; set; }
        }

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
                var training = _context
                    .Trainings
                    .Include(x => x.Exercises)
                    .ThenInclude(x => x.Sets)
                    .Where(x => x.Id == request.Id)
                    .FirstOrDefaultAsync(cancellationToken);

                if (training == null)
                    return null;

                // parse data for all charts
                // total volume
                // volume split
                // weighted average intensity
                // number of lifts
                // relative zone of intensity


                return new GetTrainingReportsResponse();
            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(GetTrainingReportsRequest), e);
            }
        }
    }

}
