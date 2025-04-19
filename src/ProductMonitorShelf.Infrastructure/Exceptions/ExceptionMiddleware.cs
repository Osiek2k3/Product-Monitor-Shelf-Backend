using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProductMonitorShelf.Core.Exceptions;
using System.Text.Json;

namespace ProductMonitorShelf.Infrastructure.Exceptions
{
    internal sealed class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(ex, context);
            }
        }
        private static async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            var (statusCode, error) = exception switch
            {
                CustomException => (StatusCodes.Status400BadRequest,
                    new Error(exception.GetType().Name.Underscore().Replace("_exception", string.Empty), exception.Message)),
                _ => (StatusCodes.Status400BadRequest,
                new Error("error", "There was an error."))
            };
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }

        private record Error(string Code, string Reason);
    }
}