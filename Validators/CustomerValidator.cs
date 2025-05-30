﻿using FluentValidation;
using WorkshopBookingSystemWebAPI.DTOs;
using WorkshopBookingSystemWebAPI.Interfaces;

namespace WorkshopBookingSystemWebAPI.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerInputDto >
    {
        private readonly IVehicleApiService _vehicleApiService;

        public CustomerValidator(IVehicleApiService vehicleApiService)
        {
            _vehicleApiService = vehicleApiService;

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.")
                .Length(2, 50)
                .WithMessage("First name must be between 2 and 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.")
                .Length(2, 50)
                .WithMessage("Last name must be between 2 and 50 characters.");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address is required.")
                .Length(5, 100)
                .WithMessage("Address must be between 5 and 100 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .Matches(@"^\+?[0-9]{10,15}$")
                .WithMessage("Phone number must be a valid format.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Email must be a valid email address.");

            RuleFor(x => x.VehicleMake)
                .NotEmpty()
                .WithMessage("Vehicle make is required.")
                .MustAsync(async (vehicleMake, cancellationToken) =>
                    await _vehicleApiService.DoesVehicleMakeExistAsync(vehicleMake, cancellationToken))
                .WithMessage("The vehicle make is not valid.");
        }
    }
}
