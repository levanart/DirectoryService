using DirectoryService.Domain.ValueObjects.Location;

namespace DirectoryService.Domain.Entities;

public class Location
{
    private Location(){} //EF CORE
    
    public Location(LocationName name, LocationAddress address, LocationTimezone timezone)
    {
        Id = Guid.NewGuid();
        Name = name;
        Address = address;
        Timezone = timezone;
        
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public Guid Id { get; private set; }
    public LocationName Name { get; private set; }
    public LocationAddress Address { get; private set; }
    public LocationTimezone Timezone { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void ChangeName(LocationName newName)
    {
        Name = newName;
    }

    public void ChangeAddress(LocationAddress newAddress)
    {
        Address = newAddress;
    }

    public void ChangeTimezone(LocationTimezone newTimezone)
    {
        Timezone = newTimezone;
    }
}