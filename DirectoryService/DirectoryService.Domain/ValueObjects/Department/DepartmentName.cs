namespace DirectoryService.Domain.ValueObjects.Department;

public record DepartmentName
{
    public string Name { get; }

    public DepartmentName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Department name cannot be empty.");
        
        if (name.Length < 3 || name.Length > 150)
            throw new ArgumentException("The department name must be between 3 and 150 characters");

        Name = name;
    }
}