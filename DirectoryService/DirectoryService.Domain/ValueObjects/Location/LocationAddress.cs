namespace DirectoryService.Domain.ValueObjects.Location;

public struct LocationAddress
{
    public string Country { get; }
    public string Town { get; }
    public string Street { get; }
    public string BuildingNumber { get; }

    public LocationAddress(string country, string street, string buildingNumber, string town)
    {
        Country = country;
        Town = town;
        Street = street;
        BuildingNumber = buildingNumber;
    }
}