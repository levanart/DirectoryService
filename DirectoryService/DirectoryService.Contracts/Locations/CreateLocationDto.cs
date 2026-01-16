namespace DirectoryService.Contracts.Locations;

public record CreateLocationDto
{
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string BuildingNumber { get; set; } = null!;
    public string Town { get; set; } = null!;
    public string Timezone { get; set; } = null!;
}