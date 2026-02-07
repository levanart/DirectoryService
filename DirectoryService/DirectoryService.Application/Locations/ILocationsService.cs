using CSharpFunctionalExtensions;
using DirectoryService.Contracts.Locations;
using Shared;

namespace DirectoryService.Application.Locations;

public interface ILocationsService
{
    public Task<Result<Guid, Failure>> CreateAsync(CreateLocationDto request, CancellationToken cancellationToken);
}