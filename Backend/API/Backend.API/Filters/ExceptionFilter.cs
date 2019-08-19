using Backend.API.Models;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using SystemException = Backend.Domain.Entities.System.SystemException;

namespace Backend.API.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IApplicationDbContext _context;

        public ExceptionFilter(IApplicationDbContext context)
        {
            _context = context;
        }

        public override async void OnException(ExceptionContext context)
        {
            var code = HttpStatusCode.InternalServerError;
            var exceptionMessage = context.Exception.Message;
            var innerExceptionMessage = context.Exception?.InnerException?.Message;
            context.HttpContext.Response.ContentType = "application/json";

            await SaveExceptionToDb((int)code, exceptionMessage, innerExceptionMessage);

            if (context.Exception is ValidationException exception)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(
                    exception.Failures);

                return;
            }


            if (context.Exception is NotFoundException || context.Exception is DeleteFailureException)
            {
                code = HttpStatusCode.NotFound;
            }

            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new ErrorDetails()
            {
                Status = (int)code,
                Message = $"{context.Exception.Message}",
                Exception = context.Exception.InnerException
            });
        }

        private async Task SaveExceptionToDb(int code, string exceptionMessage, string innerExceptionMessage)
        {
            _context.SystemExceptions.Add(new SystemException()
            {
                StatusCode = code,
                Message = exceptionMessage,
                InnerException = innerExceptionMessage,
            });

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
