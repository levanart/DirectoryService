using DirectoryService.Contracts.Locations;
using DirectoryService.Domain.Entities;
using DirectoryService.Domain.ValueObjects.Location;
using FluentValidation;
using Microsoft.Extensions.Logging;

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

    public async Task<Guid> CreateLocationAsync(CreateLocationDto dto, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(dto, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        Location location = new Location(
            new LocationName(dto.Name),
            new LocationAddress(dto.Country, dto.Street, dto.BuildingNumber, dto.Town),
            new LocationTimezone(dto.Timezone)
        );

        var locationId = await _repository.CreateAsync(location, cancellationToken);

        _logger.LogInformation("Created location with id {locationId}", locationId);

        return locationId;
    }
}