namespace DirectoryService.Domain.Entities.Location.ValueObjects;

public record LocationName
{
    public string Name { get; }

    public LocationName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Locatio name cannot be empty.");
        
        if (name.Length < 3 || name.Length > 120)
            throw new ArgumentException("The location name must be between 3 and 120 characters");
        
        Name = name;
    }
};