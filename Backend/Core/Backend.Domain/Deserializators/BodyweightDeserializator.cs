using System;

namespace Backend.Domain.Deserializators
{
    public class BodyweightDeserializer
    {
        public string Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }

        public string UserId { get; set; }
    }
}
