using Backend.Domain;
using Backend.Library.Logging.Extensions;
using Backend.Library.Logging.Interfaces;
using Backend.Library.Logging.Models;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Threading;
using System.Threading.Tasks;
using LogLevel = Backend.Library.Logging.Models.LogLevel;
using SystemLog = Backend.Domain.Entities.System.SystemLog;

namespace Backend.Library.Logging
{
    internal class LoggingService : ILoggingService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<LoggingService> _logger;
        private readonly LogLevel _logLevel;

        public LoggingService(IApplicationDbContext context, ILogger<LoggingService> logger, LogLevelSettings settings)
        {
            _context = context;
            _logger = logger;
            _logLevel = (LogLevel)Enum.Parse(typeof(LogLevel), settings.Default, true);
            _logger.LogError("LogService running");
        }

        public async Task LogError(Exception exception, string message = null)
        {
            if (LogLevel.Error > _logLevel)
            {
                FileLog(LogLevel.Error, exception, message);
                await DatabaseLog(LogLevel.Error, exception, message);
            }
        }

        public async Task LogWarning(Exception exception, string message = null)
        {
            if (LogLevel.Warn > _logLevel)
            {
                FileLog(LogLevel.Warn, exception, message);
                await DatabaseLog(LogLevel.Warn, exception, message);
            }
        }

        public async Task LogInfo(Exception exception, string message = null)
        {
            if (LogLevel.Info > _logLevel)
            {
                FileLog(LogLevel.Info, exception, message);
                await DatabaseLog(LogLevel.Info, exception, message);
            }
        }

        public async Task LogDebug(Exception exception, string message = null)
        {
            if (LogLevel.Debug > _logLevel)
            {
                FileLog(LogLevel.Debug, exception, message);
                await DatabaseLog(LogLevel.Debug, exception, message);
            }
        }

        public async Task LogError(string message)
        {
            await this.LogError(null, message);
        }

        public async Task LogWarning(string message)
        {
            await this.LogWarning(null, message);
        }

        public async Task LogInfo(string message)
        {
            await this.LogInfo(null, message);
        }

        public async Task LogDebug(string message)
        {
            await this.LogDebug(null, message);
        }

        private void FileLog(LogLevel level, Exception exception, string message)
        {
            try
            {
                var className = exception.GetLastCalledClassName();

                if (!string.IsNullOrWhiteSpace(className))
                {
                    var fileLogger = LogManager.GetLogger(className);
                    switch (level)
                    {
                        case LogLevel.Trace:
                            fileLogger.Trace(exception, message);
                            return;
                        case LogLevel.Debug:
                            fileLogger.Debug(exception, message);
                            return;
                        case LogLevel.Info:
                            fileLogger.Info(exception, message);
                            return;
                        case LogLevel.Warn:
                            fileLogger.Warn(exception, message);
                            return;
                        case LogLevel.Error:
                            fileLogger.Error(exception, message);
                            return;
                    }
                }
                else
                {
                    switch (level)
                    {
                        case LogLevel.Trace:
                            _logger.LogTrace(exception, message);
                            return;
                        case LogLevel.Debug:
                            _logger.LogDebug(exception, message);
                            return;
                        case LogLevel.Info:
                            _logger.LogInformation(exception, message);
                            return;
                        case LogLevel.Warn:
                            _logger.LogWarning(exception, message);
                            return;
                        case LogLevel.Error:
                            _logger.LogError(exception, message);
                            return;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async Task DatabaseLog(LogLevel level, Exception exception, string message)
        {
            try
            {
                await _context.SystemLog.AddAsync(new SystemLog()
                {
                    LogLevel = level.ToString(),
                    Message = string.IsNullOrWhiteSpace(message) ? exception.Message : message,
                    InnerException = exception?.InnerException?.Message,
                });

                await _context.SaveChangesAsync(CancellationToken.None);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, $"Could not log message to database - {e.Message}");
            }
        }
    }
}
