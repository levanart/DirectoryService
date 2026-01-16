using DirectoryService.Contracts.Locations;

namespace DirectoryService.Application.Locations;

public interface ILocationsService
{
    public Task<Guid> CreateLocationAsync(CreateLocationDto request, CancellationToken cancellationToken);
}