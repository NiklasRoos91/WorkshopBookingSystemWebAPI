using FluentValidation;
using WorkshopBookingSystemWebAPI.DTOs;

namespace WorkshopBookingSystemWebAPI.Validators
{
    public class AvailableSlotValidator : AbstractValidator<CreateAvailableSlotDto>
    {
        private readonly DataValidator _dataValidator;

        public AvailableSlotValidator(DataValidator dataValidator)
        {
            _dataValidator = dataValidator;

            RuleFor(x => x.ServiceTypeId)
                .Must(serviceTypeid => _dataValidator.BeAValidServiceType(serviceTypeid))
                .WithMessage("Service type does not exist.");

            RuleFor(x => x.EmployeeId)
                .Must(employeeId => _dataValidator.BeAValidEmployee(employeeId))
                .WithMessage("Employee does not exist.");

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
