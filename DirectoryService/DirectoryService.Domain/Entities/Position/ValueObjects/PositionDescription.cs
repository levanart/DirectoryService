namespace DirectoryService.Domain.Entities.Position.ValueObjects;

public record PositionDescription
{
    public string? Description { get; }

    public PositionDescription(string? description)
    {
        if (!string.IsNullOrEmpty(description) && description.Length > 1000)
            throw new ArgumentException("Description cannot exceed 1000 characters");
        
        Description = description;
    }
};