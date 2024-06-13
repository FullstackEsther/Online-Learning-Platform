using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Exception
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Argument error: {ex.Message}");
                await HandleArgumentExceptionAsync(httpContext, ex);
            }
            // catch (Exception ex)
            // {
            //     _logger.LogError($"Something went wrong: {ex}");
            //     await HandleExceptionAsync(httpContext, ex);
            // }
        }

        private Task HandleArgumentExceptionAsync(HttpContext context, ArgumentException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }

        // private Task HandleExceptionAsync(HttpContext context, Exception exception)
        // {
        //     context.Response.ContentType = "application/json";
        //     context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        //     return context.Response.WriteAsync(new ErrorDetails()
        //     {
        //         StatusCode = context.Response.StatusCode,
        //         Message = "Internal Server Error from the custom middleware."
        //     }.ToString());
        // }
    }
}
