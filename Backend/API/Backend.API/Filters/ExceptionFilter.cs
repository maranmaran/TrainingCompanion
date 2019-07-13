using Backend.API.Models;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Threading;
using SystemException = Backend.Domain.Entities.SystemException;

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
            if (context.Exception is ValidationException exception)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(
                    exception.Failures);

                return;
            }

            var code = HttpStatusCode.InternalServerError;

            if (context.Exception is NotFoundException || context.Exception is DeleteFailureException)
            {
                code = HttpStatusCode.NotFound;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new ErrorDetails()
            {
                StatusCode = (int)code,
                Message = $"{context.Exception.Message}",
                InnerException = context.Exception.InnerException
            });

            _context.SystemExceptions.Add(new SystemException()
            {
                StatusCode = (int)code,
                Message = context.Exception.Message,
                InnerException = context.Exception.InnerException.Message,
            });

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
