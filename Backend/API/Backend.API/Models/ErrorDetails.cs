using System;
using Newtonsoft.Json;

namespace Backend.API.Models
{

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Exception InnerException { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
