using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.ValueObjects.Department;

public record DepartmentIdentifier
{
    public string Identifier { get; }

    private DepartmentIdentifier(string identifier)
    {
        Identifier = identifier;
    }

    public static Result<DepartmentIdentifier, Failure> Create(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier))
            return Error.Validation("department.identifier.required", "DepartmentIdentifier cannot be empty", "Identifier").ToFailure();

        if (identifier.Length < LengthConstants.MinNameLength)
            return Error.Validation("department.identifier.too.short", $"The identifier must be at least {LengthConstants.MinNameLength} characters", "Identifier").ToFailure();

        if (identifier.Length > LengthConstants.MaxDepartmentNameLength)
            return Error.Validation("department.identifier.too.long", $"The identifier must be less than {LengthConstants.MaxDepartmentNameLength} characters", "Identifier").ToFailure();

        if (!Regex.IsMatch(identifier, "^[a-zA-Z]+$"))
            return Error.Validation("department.identifier.invalid.characters", "The identifier must contain only Latin characters.", "Identifier").ToFailure();

        return new DepartmentIdentifier(identifier);
    }
}