using System;
using System.Linq;

namespace Backend.Common
{
    public static class Utils
    {
        public static string GetRandomHexColor(bool useHash = true, params string[] hexColorRange)
        {
            var random = new Random();
            if (!hexColorRange.Any())
            {
                return $"{(useHash ? "#" : "")}{random.Next(0x1000000):X6}"; // = "#A197B9"
            }

            return hexColorRange[random.Next(hexColorRange.Length)];
        }



    }
}
