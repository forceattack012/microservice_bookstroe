using Bookstore.Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace Middleware;
public class LoggingMiddleware
{
    private readonly Bookstore.Domain.Repositories.ILogger _logger;
    private readonly RequestDelegate _next;


    public LoggingMiddleware(ILogger logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            var request = $"Incoming request: {context.Request.Method} {context.Request.Path}";
            _logger.LogInformation(request);
            await _next(context);
        }
        catch(Exception ex)
        {
            var error = $"{ex.InnerException} \n {ex.Message}";
            _logger.LogError(error);
        }
    }
}
