using DirectoryService.Contracts.Locations;
using FluentValidation;

namespace DirectoryService.Application.Locations.CreateLocation;

public class CreateLocationValidator : AbstractValidator<CreateLocationDto>
{
    public CreateLocationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .WithErrorCode("location.name.required")
            
            .MaximumLength(120)
            .WithMessage("Name must be less than 120 characters")
            .WithErrorCode("location.name.too.long");

        
        RuleFor(x => x.Country)
            .NotEmpty()
            .WithMessage("Country is required")
            .WithErrorCode("location.country.required")
            
            .MaximumLength(100)
            .WithMessage("Country must be less than 100 characters")
            .WithErrorCode("location.country.too.long");

        
        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Street is required")
            .WithErrorCode("location.street.required")
            
            .MaximumLength(100)
            .WithMessage("Street must be less than 100 characters")
            .WithErrorCode("location.street.too.long");

        
        RuleFor(x => x.Town)
            .NotEmpty()
            .WithMessage("Town is required")
            .WithErrorCode("location.town.required")
            
            .MaximumLength(100)
            .WithMessage("Town must be less than 100 characters")
            .WithErrorCode("location.town.too.long");

        
        RuleFor(x => x.BuildingNumber)
            .NotEmpty()
            .WithMessage("BuildingNumber is required")
            .WithErrorCode("location.buildingNumber.required")
            
            .MaximumLength(20)
            .WithMessage("BuildingNumber must be less than 20 characters")
            .WithErrorCode("location.buildingNumber.too.long");

        
        RuleFor(x => x.Timezone)
            .NotEmpty()
            .WithMessage("Timezone is required")
            .WithErrorCode("location.timezone.required")
            
            .MaximumLength(100)
            .WithMessage("Timezone must be less than 100 characters")
            .WithErrorCode("location.timezone.too.long");
    }

}