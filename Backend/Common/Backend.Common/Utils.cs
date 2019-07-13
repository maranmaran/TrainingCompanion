using System;

namespace Backend.Common
{
    public static class Utils
    {
        public static string GetRandomHexColor(bool useHash = true)
        {
            var random = new Random();
            return $"{(useHash ? "#" : "")}{random.Next(0x1000000):X6}"; // = "#A197B9"
        }

     

    }
}
