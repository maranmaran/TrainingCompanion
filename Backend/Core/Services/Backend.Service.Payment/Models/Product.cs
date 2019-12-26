using System.Collections.Generic;

namespace Backend.Service.Payment.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StatementDescription { get; set; }
        public string Type { get; set; }
        public ICollection<Plan> Plans { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}