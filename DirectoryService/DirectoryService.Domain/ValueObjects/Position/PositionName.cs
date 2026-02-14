using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.ValueObjects.Position;

public record PositionName
{
    public string Name { get; }

    private PositionName(string name)
    {
        Name = name;
    }

    public static Result<PositionName, Failure> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Error.Validation("position.name.required", "Position name cannot be empty.", "Name").ToFailure();

        if (name.Length < LengthConstants.MinNameLength)
            return Error.Validation("position.name.too.short", $"The position name must be at least {LengthConstants.MinNameLength} characters", "Name").ToFailure();

        if (name.Length > LengthConstants.MaxPositionNameLength)
            return Error.Validation("position.name.too.long", $"The position name must be less than {LengthConstants.MaxPositionNameLength} characters", "Name").ToFailure();

        return new PositionName(name);
    }
}