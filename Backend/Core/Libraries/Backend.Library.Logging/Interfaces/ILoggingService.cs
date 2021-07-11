using System;
using System.Threading.Tasks;

namespace Backend.Library.Logging.Interfaces
{
    public interface ILoggingService
    {
        void DisableDbLog();

        Task LogError(Exception exception, string message = null);

        Task LogWarning(Exception exception, string message = null);

        Task LogInfo(Exception exception, string message = null);

        Task LogDebug(Exception exception, string message = null);

        Task LogError(string message);

        Task LogWarning(string message);

        Task LogInfo(string message);

        Task LogDebug(string message);
    }
}