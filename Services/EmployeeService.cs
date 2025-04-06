
using Microsoft.EntityFrameworkCore;
using WorkshopBookingSystemWebAPI.Database;
using WorkshopBookingSystemWebAPI.DTOs;
using WorkshopBookingSystemWebAPI.Interfaces;
using WorkshopBookingSystemWebAPI.Validators;
using FluentValidation;
using WorkshopBookingSystemWebAPI.Models;

namespace WorkshopBookingSystemWebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly WorkshopBookingSystemContext _context;
        private readonly EmployeeValidator _employeeValidator;

        public EmployeeService(WorkshopBookingSystemContext context, EmployeeValidator employeeValidator)
        {
            _context = context;
            _employeeValidator = employeeValidator;
        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            return await _context.Employees.Select(e => new EmployeeDto
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
            })
            .ToListAsync();
        }

        public async Task<EmployeeDto?> GetEmployeeById(int employeeId)
        {
            return await _context.Employees.Where(e => e.EmployeeId == employeeId)
                .Select(e => new EmployeeDto
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<EmployeeInputDto > CreateEmployee(EmployeeInputDto  employee)
        {
            var validationResult = _employeeValidator.Validate(employee);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Employee newEmployee = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
            };

            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();

            return new EmployeeInputDto 
            {
                FirstName = newEmployee.FirstName,
                LastName = newEmployee.LastName,
                Email = newEmployee.Email,
                PhoneNumber = newEmployee.PhoneNumber,
            };
        }

        public async Task<EmployeeInputDto > UpdateEmployee(int employeeId, EmployeeInputDto  employee)
        {
            var validationResult = _employeeValidator.Validate(employee);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var employeeToUpdate = await _context.Employees.FindAsync(employeeId);

            if (employeeToUpdate == null)
            {
                return null;
            }

            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.Email = employee.Email;
            employeeToUpdate.PhoneNumber = employee.PhoneNumber;

            await _context.SaveChangesAsync();

            return new EmployeeInputDto 
            {
                FirstName = employeeToUpdate.FirstName,
                LastName = employeeToUpdate.LastName,
                Email = employeeToUpdate.Email,
                PhoneNumber = employeeToUpdate.PhoneNumber,
            };
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            var employeeToDelete = await _context.Employees.FindAsync(employeeId);

            if (employeeToDelete == null)
            {
                return false;
            }

            _context.Employees.Remove(employeeToDelete);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
