using CSharpFunctionalExtensions;
using DirectoryService.Application.Abstractions;
using DirectoryService.Application.Extensions;
using DirectoryService.Contracts.Locations;
using DirectoryService.Domain.Entities;
using DirectoryService.Domain.ValueObjects.Location;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared;

namespace DirectoryService.Application.Locations.CreateLocation;

public class CreateLocationHandler : ICommandHandler<CreateLocationCommand, Guid>
{
    private readonly ILocationsRepository _repository;
    private readonly IValidator<CreateLocationDto> _validator;
    private readonly ILogger<CreateLocationHandler> _logger;

    public CreateLocationHandler(ILocationsRepository locationsRepository, ILogger<CreateLocationHandler> logger,
        IValidator<CreateLocationDto> validator)
    {
        _repository = locationsRepository;
        _logger = logger;
        _validator = validator;
    }

    public async Task<Result<Guid, Failure>> Handle(CreateLocationCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command.CreateLocationDto, cancellationToken);
        if (!validationResult.IsValid)
            return validationResult.ToErrors();
        
        var locationName = LocationName.Create(command.CreateLocationDto.Name).Value;
        
        var locationAddress = LocationAddress.Create(command.CreateLocationDto.Country, command.CreateLocationDto.Street,
            command.CreateLocationDto.BuildingNumber, command.CreateLocationDto.Town).Value;
        
        var locationTimezone = LocationTimezone.Create(command.CreateLocationDto.Timezone).Value;

        var location = new Location(locationName, locationAddress, locationTimezone);

        var locationId = await _repository.AddAsync(location, cancellationToken);

        _logger.LogInformation("Created location with id {locationId}", locationId);

        return locationId;
    }
}