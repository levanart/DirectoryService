using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.ValueObjects.Location;

public record LocationTimezone
{
    public string Timezone { get; }

    private LocationTimezone(string timezone)
    {
        Timezone = timezone;
    }

    public static Result<LocationTimezone, Failure> Create(string timezone)
    {
        if (string.IsNullOrWhiteSpace(timezone))
            return Error.Validation("location.timezone.required", "Timezone cannot be empty.", "Timezone").ToFailure();

        return new LocationTimezone(timezone);
    }
}