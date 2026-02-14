using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.ValueObjects.Department;

public record DepartmentName
{
    public string Name { get; }

    private DepartmentName(string name)
    {
        Name = name;
    }

    public static Result<DepartmentName, Failure> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Error.Validation("department.name.required", "Department name cannot be empty.", "Name").ToFailure();

        if (name.Length < LengthConstants.MinNameLength)
            return Error.Validation("department.name.too.short", $"The department name must be at least {LengthConstants.MinNameLength} characters", "Name").ToFailure();

        if (name.Length > LengthConstants.MaxDepartmentNameLength)
            return Error.Validation("department.name.too.long", $"The department name must be less than {LengthConstants.MaxDepartmentNameLength} characters", "Name").ToFailure();

        return new DepartmentName(name);
    }
}