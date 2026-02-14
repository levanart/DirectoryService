using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.ValueObjects.Location;

public record LocationName
{
    public string Name { get; }

    private LocationName(string name)
    {
        Name = name;
    }

    public static Result<LocationName, Failure> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Error.Validation("location.name.required", "Location name cannot be empty.", "Name").ToFailure();

        if (name.Length < LengthConstants.MinNameLength)
            return Error.Validation("location.name.too.short", $"The location name must be at least {LengthConstants.MinNameLength} characters", "Name").ToFailure();

        if (name.Length > LengthConstants.MaxLocationNameLength)
            return Error.Validation("location.name.too.long", $"The location name must be less than {LengthConstants.MaxLocationNameLength} characters", "Name").ToFailure();

        return new LocationName(name);
    }
}
