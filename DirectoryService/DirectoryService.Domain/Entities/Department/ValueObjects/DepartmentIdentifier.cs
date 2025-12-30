using System.Text.RegularExpressions;

namespace DirectoryService.Domain.Entities.Department.ValueObjects;

public record DepartmentIdentifier
{
    public string Identifier { get; }

    public DepartmentIdentifier(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier))
            throw new ArgumentException("Identifier cannot be empty.");
        
        if (identifier.Length < 3 || identifier.Length > 150)
            throw new ArgumentException("The identifier must be between 3 and 150 characters");
        
        if (!Regex.IsMatch(identifier, @"^[a-zA-Z]+$"))
            throw new ArgumentException("The identifier must contain only Latin characters.");
        
        Identifier = identifier;
    }
};