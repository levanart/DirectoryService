using System.Text.Json;
using Shared;

namespace DirectoryService.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(IEnumerable<Error> errors) : base(JsonSerializer.Serialize(errors))
    {
    }
}