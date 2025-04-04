using FluentValidation;
using WorkshopBookingSystemWebAPI.DTOs;

namespace WorkshopBookingSystemWebAPI.Validators
{
    public class ServiceTypeValidator :AbstractValidator<CreateServiceTypeDto>
    {
        public ServiceTypeValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .WithMessage("Service type name is required.")
                .Length(2, 50)
                .WithMessage("Service type name must be between 2 and 50 characters long.");

            RuleFor(s => s.Price)
                .NotEmpty()
                .WithMessage("Service type price is required.")
                 .GreaterThanOrEqualTo(0)
                .WithMessage("The price must be a positive number. Please check the value.");


            RuleFor(s => s.Duration)
                .NotEmpty()
                .WithMessage("Service type duration is required.")
                .GreaterThanOrEqualTo(TimeSpan.Zero)
                .WithMessage("Duration cannot be negative. Please enter a valid duration.");
        }
    }
}
