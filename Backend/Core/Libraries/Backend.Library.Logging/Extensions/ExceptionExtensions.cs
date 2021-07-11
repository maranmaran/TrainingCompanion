using System;
using System.Diagnostics;
using System.Linq;

namespace Backend.Library.Logging.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetLastCalledMethod(this Exception ex)
        {
            if (ex == null)
                return null;

            var stackTrace = new StackTrace(ex);
            var lastFrame = stackTrace.GetFrames().FirstOrDefault();

            var methodName = string.Empty;
            if (lastFrame != null)
                methodName = lastFrame.GetMethod().Name;

            return methodName;
        }

        public static string GetLastCalledClassName(this Exception ex)
        {
            if (ex == null)
                return null;

            var stackTrace = new StackTrace(ex);
            var lastFrame = stackTrace.GetFrames().FirstOrDefault();

            return lastFrame?.GetFileName();
        }
    }
}