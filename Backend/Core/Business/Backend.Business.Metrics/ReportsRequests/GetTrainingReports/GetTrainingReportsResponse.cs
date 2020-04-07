using Backend.Business.Reports.Models;

namespace Backend.Business.Reports.ReportsRequests.GetTrainingReports
{
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
}