using Backend.API.Models;
using Backend.Infrastructure.Exceptions;
using Backend.Library.Logging.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Backend.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ILoggingService logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(logger, httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(ILoggingService logger, HttpContext context, Exception exception)
        {
            await logger.LogError(exception, $"{exception.Message} {exception.InnerException?.Message}");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var errorDetails = new ErrorDetails()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Message = "Something went wrong",
                Exception = exception
            };

            if (exception is ExtendedException extendedException)
            {
                errorDetails.Status = extendedException.Status;
                errorDetails.Message = extendedException.Message;
                errorDetails.Exception = extendedException.Exception;
            }
            await context.Response.WriteAsync(errorDetails.ToString());
        }
    }
}