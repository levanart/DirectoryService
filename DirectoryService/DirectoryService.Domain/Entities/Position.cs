using DirectoryService.Domain.ValueObjects.Position;

namespace DirectoryService.Domain.Entities;

public class Position
{
    private Position(){} //EF CORE
    
    public Position(PositionName name, PositionDescription description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }

    public Guid Id { get; private set; }
    public PositionName Name { get; private set; }
    public PositionDescription Description { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void Rename(PositionName newName)
    {
        Name = newName;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void ChangeDescription(PositionDescription newDescription)
    {
        Description = newDescription;
        UpdatedAt = DateTime.UtcNow;
    }
}