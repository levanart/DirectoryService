using DirectoryService.Domain.Entities.Department.ValueObjects;

namespace DirectoryService.Domain.Entities.Department;

public class Department
{
    public Department(DepartmentName name,
        DepartmentIdentifier identifier,
        Guid? parentId,
        string path)
    {
        Id = Guid.NewGuid();
        Name = name;
        Identifier = identifier;
        ParentId = parentId;
        Path = path;
        Depth = path.Split(".").Length;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public DepartmentName Name { get; private set; }
    public DepartmentIdentifier Identifier { get; private set; }
    public Guid? ParentId { get; private set; }
    public string Path { get; private set; }
    public int Depth { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    public void Rename(DepartmentName newName)
    {
        Name = newName;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void ChangeIdentifier(DepartmentIdentifier newIdentifier)
    {
        Identifier = newIdentifier;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangeParentId(Guid? newParentId)
    {
        ParentId = newParentId;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangePath(string path)
    {
        Path = path;
        Depth = path.Split(".").Length;
        UpdatedAt = DateTime.UtcNow;
    }
}