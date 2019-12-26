using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Backend.API.Models
{
    public class ErrorDetails
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("exception")]
        public Exception Exception { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}