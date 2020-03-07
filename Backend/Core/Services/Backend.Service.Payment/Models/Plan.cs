using System.Collections.Generic;
using Backend.Library.Payment.Enums;

namespace Backend.Library.Payment.Models
{
    public class Plan
    {
        public string Name { get; set; }
        public long? PricePerUnit { get; set; }
        public PlanInterval Interval { get; set; } = PlanInterval.Month;
        public PlanCurrency PlanCurrency { get; set; } = PlanCurrency.USD;
        public Dictionary<string, string> Metadata { get; set; }
    }
}