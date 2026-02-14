using DirectoryService.Contracts.Locations;
using FluentValidation;
using Shared;

namespace DirectoryService.Application.Locations.CreateLocation;

public class CreateLocationValidator : AbstractValidator<CreateLocationDto>
{
    public CreateLocationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .WithErrorCode("location.name.required")
            
            .MinimumLength(LengthConstants.MinNameLength)
            .WithMessage($"Name must be at least {LengthConstants.MinNameLength} characters")
            .WithErrorCode("location.name.too.short")
            
            .MaximumLength(LengthConstants.MaxLocationNameLength)
            .WithMessage($"Name must be less than {LengthConstants.MaxLocationNameLength} characters")
            .WithErrorCode("location.name.too.long");

        
        RuleFor(x => x.Country)
            .NotEmpty()
            .WithMessage("Country is required")
            .WithErrorCode("location.country.required")
            
            .MaximumLength(LengthConstants.MaxCountryLength)
            .WithMessage($"Country must be less than {LengthConstants.MaxCountryLength} characters")
            .WithErrorCode("location.country.too.long");

        
        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Street is required")
            .WithErrorCode("location.street.required")
            
            .MaximumLength(LengthConstants.MaxStreetLength)
            .WithMessage($"Street must be less than {LengthConstants.MaxStreetLength} characters")
            .WithErrorCode("location.street.too.long");

        
        RuleFor(x => x.Town)
            .NotEmpty()
            .WithMessage("Town is required")
            .WithErrorCode("location.town.required")
            
            .MaximumLength(LengthConstants.MaxTownLength)
            .WithMessage($"Town must be less than {LengthConstants.MaxTownLength} characters")
            .WithErrorCode("location.town.too.long");

        
        RuleFor(x => x.BuildingNumber)
            .NotEmpty()
            .WithMessage("BuildingNumber is required")
            .WithErrorCode("location.buildingNumber.required")
            
            .MaximumLength(LengthConstants.MaxBuildingNumberLength)
            .WithMessage($"BuildingNumber must be less than {LengthConstants.MaxBuildingNumberLength} characters")
            .WithErrorCode("location.buildingNumber.too.long");

        
        RuleFor(x => x.Timezone)
            .NotEmpty()
            .WithMessage("Timezone is required")
            .WithErrorCode("location.timezone.required")
            
            .MaximumLength(LengthConstants.MaxTimezoneLength)
            .WithMessage($"Timezone must be less than {LengthConstants.MaxTimezoneLength} characters")
            .WithErrorCode("location.timezone.too.long");
    }

}