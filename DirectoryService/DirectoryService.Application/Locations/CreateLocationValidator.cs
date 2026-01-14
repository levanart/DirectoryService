using DirectoryService.Contracts.Locations;
using FluentValidation;

namespace DirectoryService.Application.Locations;

public class CreateLocationValidator : AbstractValidator<CreateLocationDto>
{
    public CreateLocationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(120).WithMessage("Name must be less than 120 characters");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required")
            .MaximumLength(100).WithMessage("Country must be less than 100 characters");
        
        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Street is required")
            .MaximumLength(100).WithMessage("Street must be less than 100 characters");
        
        RuleFor(x => x.Town)
            .NotEmpty().WithMessage("Town is required")
            .MaximumLength(100).WithMessage("Town must be less than 100 characters");
        
        RuleFor(x => x.BuildingNumber)
            .NotEmpty().WithMessage("BuildingNumber is required")
            .MaximumLength(20).WithMessage("BuildingNumber must be less than 20 characters");
        
        RuleFor(x => x.Timezone)
            .NotEmpty().WithMessage("Timezone is required")
            .MaximumLength(100).WithMessage("Timezone must be less than 100 characters");
    }
}