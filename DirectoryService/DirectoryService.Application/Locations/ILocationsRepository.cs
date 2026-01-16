using DirectoryService.Domain.Entities;

namespace DirectoryService.Application.Locations;

public interface ILocationsRepository
{
    public Task<Guid> AddAsync(Location location, CancellationToken cancellationToken);
}