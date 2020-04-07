using System.Collections.Generic;

namespace Backend.Business.Reports.Models
{
    public class ChartDataSet<T>
    {
        public ChartDataSet()
        {
            Data = new List<T>();
        }

        public IEnumerable<T> Data { get; set; }
    }
}