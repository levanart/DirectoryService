namespace DirectoryService.Domain.Entities.Location.ValueObjects;

public struct LocationAddress
{
    public string Address { get; }

    public LocationAddress(string address)
    {
        Address = address;
    }
}