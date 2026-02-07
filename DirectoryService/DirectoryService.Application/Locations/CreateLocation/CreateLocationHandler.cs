using CSharpFunctionalExtensions;
using DirectoryService.Application.Extensions;
using DirectoryService.Contracts.Locations;
using DirectoryService.Domain.Entities;
using DirectoryService.Domain.ValueObjects.Location;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared;

namespace DirectoryService.Application.Locations.CreateLocation;

public record CreateLocationCommand(CreateLocationDto CreateLocationDto);

public class CreateLocationHandler
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

        var location = new Location(
            new LocationName(command.CreateLocationDto.Name),
            new LocationAddress(command.CreateLocationDto.Country, command.CreateLocationDto.Street,
                command.CreateLocationDto.BuildingNumber, command.CreateLocationDto.Town),
            new LocationTimezone(command.CreateLocationDto.Timezone)
        );

        var locationId = await _repository.AddAsync(location, cancellationToken);

        _logger.LogInformation("Created location with id {locationId}", locationId);

        return locationId;
    }
}