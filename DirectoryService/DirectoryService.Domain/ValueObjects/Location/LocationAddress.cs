using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.ValueObjects.Location;

public record LocationAddress
{
    public string Country { get; }
    public string Town { get; }
    public string Street { get; }
    public string BuildingNumber { get; }

    private LocationAddress(string country, string street, string buildingNumber, string town)
    {
        Country = country;
        Town = town;
        Street = street;
        BuildingNumber = buildingNumber;
    }

    public static Result<LocationAddress, Failure> Create(string country, string street, string buildingNumber, string town)
    {
        if (string.IsNullOrWhiteSpace(country))
            return Error.Validation("location.country.required", "Country cannot be empty.", "Country").ToFailure();

        if (string.IsNullOrWhiteSpace(street))
            return Error.Validation("location.street.required", "Street cannot be empty.", "Street").ToFailure();

        if (string.IsNullOrWhiteSpace(buildingNumber))
            return Error.Validation("location.buildingNumber.required", "Building number cannot be empty.", "BuildingNumber").ToFailure();

        if (string.IsNullOrWhiteSpace(town))
            return Error.Validation("location.town.required", "Town cannot be empty.", "Town").ToFailure();

        return new LocationAddress(country, street, buildingNumber, town);
    }
}