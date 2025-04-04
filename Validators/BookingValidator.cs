using FluentValidation;
using WorkshopBookingSystemWebAPI.DTOs;
using WorkshopBookingSystemWebAPI.Models;

namespace WorkshopBookingSystemWebAPI.Validators
{
    public class BookingValidator : AbstractValidator<CreateBookingDto>
    {
        private readonly DataValidator _dataValidator;

        public BookingValidator(DataValidator dataValidator)
        {
            _dataValidator = dataValidator;

            RuleFor(x => x.ServiceTypeId)
                .Must(serviceTypeid => _dataValidator.BeAValidServiceType(serviceTypeid))
                .WithMessage("Service type does not exist.");

            RuleFor(x => x.EmployeeId)
                .Must(employeeId => _dataValidator.BeAValidEmployee(employeeId))
                .WithMessage("Employee does not exist.");

            RuleFor(c => c.CustomerId)
                .Must(customerId => _dataValidator.BeAValidCustomer(customerId))
                .WithMessage("Customer does not exist.");                

            RuleFor(x => x.StartTime)
                .NotEmpty()
                .WithMessage("Start time is required.")
                .GreaterThan(DateTime.Now)
                .WithMessage("Start time must be in the future.");

            RuleFor(x => x.EndTime)
                .NotEmpty()
                .WithMessage("End time is required.")
                .GreaterThan(x => x.StartTime)
                .WithMessage("End time must be later than start time.");
        }
    }
}
