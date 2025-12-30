namespace DirectoryService.Domain.Entities.Location.ValueObjects;

public record LocationTimezone
{
    public string Timezone { get; }
    
    public LocationTimezone(string timezone)
    {
        Timezone = timezone;
    }
}