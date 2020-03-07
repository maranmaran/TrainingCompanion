using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Library.Logging.Interfaces;
using SystemException = Backend.Domain.Entities.System.SystemException;

namespace Backend.Library.Logging
{
    internal class LoggingService : ILoggingService
    {
        private readonly IApplicationDbContext _context;

        public LoggingService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task LogError(int code, string message, string details, CancellationToken cancellationToken = default)
        {
            try
            {

                await _context.SystemExceptions.AddAsync(new SystemException()
                {
                    StatusCode = code,
                    Message = message,
                    InnerException = details,
                }, cancellationToken);

                await _context.SaveChangesAsync(CancellationToken.None);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
