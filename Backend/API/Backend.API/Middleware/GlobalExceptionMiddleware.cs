using Backend.API.Models;
using Backend.Service.Infrastructure.Exceptions;
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

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
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
