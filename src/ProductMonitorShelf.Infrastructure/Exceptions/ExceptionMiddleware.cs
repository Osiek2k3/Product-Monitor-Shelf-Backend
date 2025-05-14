using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProductMonitorShelf.Core.Exceptions;
using System.Text.Json;

namespace ProductMonitorShelf.Infrastructure.Exceptions
{
    public sealed class ExceptionMiddleware : IMiddleware
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
                NotFoundException => (
                    StatusCodes.Status404NotFound,
                    new Error("not_found", exception.Message)
                ),
                DatabaseException => (
                    StatusCodes.Status500InternalServerError,
                    new Error("database_error", exception.Message)
                ),
                _ => (
                    StatusCodes.Status500InternalServerError,
                    new Error("internal_error", "Wystąpił nieoczekiwany błąd.")
                )
            };

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }

        private record Error(string Code, string Reason);

    }
}