﻿using FluentValidation;
using WorkshopBookingSystemWebAPI.DTOs;

namespace WorkshopBookingSystemWebAPI.Validators
{
    public class ServiceTypeValidator :AbstractValidator<ServiceTypeInputDto>
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
                .Must(d => TimeSpan.TryParse(d, out _))
                .WithMessage("Duration must be a valid format (HH:mm:ss).");
        }
    }
}
