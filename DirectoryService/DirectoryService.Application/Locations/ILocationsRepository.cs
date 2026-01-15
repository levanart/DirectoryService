using DirectoryService.Domain.Entities;

namespace DirectoryService.Application.Locations;

public interface ILocationsRepository
{
    public Task<Guid> CreateAsync(Location location, CancellationToken cancellationToken);
}