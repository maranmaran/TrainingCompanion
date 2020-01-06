using System.Threading;
using System.Threading.Tasks;

namespace Backend.Service.Logging.Interfaces
{
    public interface ILoggingService
    {
        Task LogError(int code, string message, string details, CancellationToken cancellationToken = default);
    }
}
