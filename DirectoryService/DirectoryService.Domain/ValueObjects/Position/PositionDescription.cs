using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.ValueObjects.Position;

public record PositionDescription
{
    public string? Description { get; }

    private PositionDescription(string? description)
    {
        Description = description;
    }

    public static Result<PositionDescription, Failure> Create(string? description)
    {
        if (!string.IsNullOrEmpty(description) && description.Length > LengthConstants.MaxDescriptionLength)
            return Error.Validation("position.description.too.long", $"Description cannot exceed {LengthConstants.MaxDescriptionLength} characters", "Description").ToFailure();

        return new PositionDescription(description);
    }
}
