using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backend.Common.Extensions
{
    public static class CommonExtensions
    {
        public static T Clone<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
