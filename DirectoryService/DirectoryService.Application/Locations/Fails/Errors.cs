using Shared;

namespace DirectoryService.Application.Locations.Fails;

public partial class Errors
{
    public static class Locations
    {
        public static Error ValidationFailed(string? invalidField) =>
            Error.Validation(null, "Location validation failed", invalidField);
    }
}