using System.Text.Json;
using DirectoryService.Application.Exceptions;
using Shared;

namespace DirectoryService.Presentation.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (code, errors) = exception switch
        {
            BadRequestException => (StatusCodes.Status400BadRequest,
                JsonSerializer.Deserialize<IEnumerable<Error>>(exception.Message)),
            
            NotFoundException => (StatusCodes.Status404NotFound,
                JsonSerializer.Deserialize<IEnumerable<Error>>(exception.Message)),
            
            _ => (StatusCodes.Status500InternalServerError, [Error.Failure(null, "Internal Server Error")])
        };
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = code;
        
        if (code == StatusCodes.Status500InternalServerError)
            _logger.LogError(exception, exception.Message);
        
        await context.Response.WriteAsync(JsonSerializer.Serialize(errors));
    }
}

public static class ExceptionMiddlewareExtension
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder) =>
        builder.UseMiddleware<ExceptionMiddleware>();
}