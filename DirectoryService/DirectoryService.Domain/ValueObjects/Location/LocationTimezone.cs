namespace DirectoryService.Domain.ValueObjects.Location;

public record LocationTimezone
{
    public string Timezone { get; }
    
    public LocationTimezone(string timezone)
    {
        Timezone = timezone;
    }
}