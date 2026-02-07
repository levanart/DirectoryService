using CSharpFunctionalExtensions;
using DirectoryService.Application.Extensions;
using DirectoryService.Contracts.Locations;
using DirectoryService.Domain.Entities;
using DirectoryService.Domain.ValueObjects.Location;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared;

namespace DirectoryService.Application.Locations;

public class LocationsService : ILocationsService
{
    private readonly ILocationsRepository _repository;
    private readonly IValidator<CreateLocationDto> _validator;
    private readonly ILogger<LocationsService> _logger;

    public LocationsService(ILocationsRepository repository, IValidator<CreateLocationDto> validator,
        ILogger<LocationsService> logger)
    {
        _repository = repository;
        _validator = validator;
        _logger = logger;
    }

    public async Task<Result<Guid, Failure>> CreateAsync(CreateLocationDto request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return validationResult.ToErrors();

        var location = new Location(
            new LocationName(request.Name),
            new LocationAddress(request.Country, request.Street, request.BuildingNumber, request.Town),
            new LocationTimezone(request.Timezone)
        );

        var locationId = await _repository.AddAsync(location, cancellationToken);

        _logger.LogInformation("Created location with id {locationId}", locationId);

        return locationId;
    }
}