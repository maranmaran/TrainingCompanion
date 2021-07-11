using System.Collections.Generic;

namespace Backend.Business.Reports.Models
{
    public class ChartData<TData, TLabel>
    {
        public ChartData()
        {
            Labels = new List<TLabel>();
            DataSets = new List<ChartDataSet<TData>>();
        }

        public List<TLabel> Labels { get; set; }
        public List<ChartDataSet<TData>> DataSets { get; set; }
    }

    // default label type
    public class ChartData<TData> : ChartData<TData, string>
    {
    }
}