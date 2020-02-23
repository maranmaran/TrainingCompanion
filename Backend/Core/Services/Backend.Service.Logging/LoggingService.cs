using Backend.Domain;
using Backend.Service.Logging.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using SystemException = Backend.Domain.Entities.System.SystemException;

namespace Backend.Service.Logging
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
