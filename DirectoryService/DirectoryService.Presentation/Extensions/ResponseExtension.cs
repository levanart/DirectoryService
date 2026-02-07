using Microsoft.AspNetCore.Mvc;
using Shared;

namespace DirectoryService.Presentation.Extensions;

public static class ResponseExtension
{
    public static ActionResult ToResponse(this Failure failure)
    {
        if (!failure.Any())
        {
            return new ObjectResult(null)
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };
        }

        var distinctErrorTypes = failure
            .Select(e => e.Type)
            .Distinct()
            .ToList();
        
        int statusCode = distinctErrorTypes.Count > 1
            ? StatusCodes.Status500InternalServerError
            : GetStatusCodeFromErrorType(distinctErrorTypes.First());

        return new ObjectResult(failure)
        {
            StatusCode = statusCode
        };
    }

    private static int GetStatusCodeFromErrorType(ErrorType type) => type switch
    {
        ErrorType.None => StatusCodes.Status200OK,
        ErrorType.Validation => StatusCodes.Status400BadRequest,
        ErrorType.NotFound => StatusCodes.Status404NotFound,
        ErrorType.Conflict => StatusCodes.Status409Conflict,
        ErrorType.Failure => StatusCodes.Status500InternalServerError,
        _ => StatusCodes.Status500InternalServerError
    };
}