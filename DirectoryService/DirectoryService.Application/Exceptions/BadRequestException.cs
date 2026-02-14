using System.Text.Json;
using Shared;

namespace DirectoryService.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(IEnumerable<Error> errors) : base(JsonSerializer.Serialize(errors))
    {
    }
}