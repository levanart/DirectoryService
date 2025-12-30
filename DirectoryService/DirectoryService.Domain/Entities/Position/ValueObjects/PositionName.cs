namespace DirectoryService.Domain.Entities.Position.ValueObjects;

public record PositionName
{
    public string Name { get; }

    public PositionName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Position name cannot be empty.");
        
        if (name.Length < 3 || name.Length > 100)
            throw new ArgumentException("The position name must be between 3 and 100 characters");
        
        Name = name;
    }
}