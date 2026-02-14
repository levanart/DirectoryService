using Microsoft.AspNetCore.Http;

namespace Shared.EndpointResults;

public class FailureResult : IResult
{
    private readonly Failure _failure;

    public FailureResult(Failure failure)
    {
        _failure = failure;
    }
    
    public Task ExecuteAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);

        if (!_failure.Any())
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            
            return httpContext.Response.WriteAsJsonAsync(Envelope.Error(_failure));
        }

        var distinctErrorTypes = _failure
            .Select(x => x.Type)
            .Distinct()
            .ToList();

        int statusCode = distinctErrorTypes.Count > 1
            ? StatusCodes.Status500InternalServerError
            : GetStatusCodeForErrorType(distinctErrorTypes.First());
        
        var envelope = Envelope.Error(_failure);
        httpContext.Response.StatusCode = statusCode;
        
        return httpContext.Response.WriteAsJsonAsync(envelope);
    }

    private static int GetStatusCodeForErrorType(ErrorType errorType) =>
        errorType switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Failure => StatusCodes.Status500InternalServerError,
            _ => StatusCodes.Status500InternalServerError
        };
}