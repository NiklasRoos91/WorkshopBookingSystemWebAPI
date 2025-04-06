using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WorkshopBookingSystemWebAPI.Database;
using WorkshopBookingSystemWebAPI.DTOs;
using WorkshopBookingSystemWebAPI.Interfaces;
using WorkshopBookingSystemWebAPI.Models;
using WorkshopBookingSystemWebAPI.Validators;

namespace WorkshopBookingSystemWebAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly WorkshopBookingSystemContext _context;
        private readonly CustomerValidator _customerValidator;

        public CustomerService(WorkshopBookingSystemContext context, CustomerValidator customerValidator)
        {
            _context = context;
            _customerValidator = customerValidator;
        }
        public async Task<List<CustomerDto>> GetAllCustomers()
        {
            return await _context.Customers.Select(c => new CustomerDto
            {
                CustomerId = c.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address,
                VehicleMake = c.VehicleMake,
            })
            .ToListAsync();
        }
        public async Task<CustomerDto?> GetCustomersById(int customerId)
        {
            return await _context.Customers.Where(c => c.CustomerId == customerId)
                .Select(c => new CustomerDto
                {
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    VehicleMake = c.VehicleMake,
                })
                .FirstOrDefaultAsync();
        }
        public async Task<CustomerInputDto> CreateCustomer(CustomerInputDto customer)
        {
            var validaitionResult = _customerValidator.Validate(customer);
            if (!validaitionResult.IsValid)
            {
                throw new ValidationException(validaitionResult.Errors);
            }
            Customer newCustomer = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                VehicleMake = customer.VehicleMake,
            };
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            return new CustomerInputDto
            {
                FirstName = newCustomer.FirstName,
                LastName = newCustomer.LastName,
                Email = newCustomer.Email,
                PhoneNumber = newCustomer.PhoneNumber,
                Address = newCustomer.Address,
                VehicleMake = newCustomer.VehicleMake,
            };
        }
        public async Task<CustomerInputDto> UpdateCustomer(int customerId, CustomerInputDto customer)
        {
            var validationResult = _customerValidator.Validate(customer);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var customerToUpdate = _context.Customers.Find(customerId);

            if (customerToUpdate == null)
            {
                return null;
            }

            customerToUpdate.FirstName = customer.FirstName;
            customerToUpdate.LastName = customer.LastName;
            customerToUpdate.Email = customer.Email;
            customerToUpdate.PhoneNumber = customer.PhoneNumber;
            customerToUpdate.Address = customer.Address;
            customerToUpdate.VehicleMake = customer.VehicleMake;

            await _context.SaveChangesAsync();

            return new CustomerInputDto
            {
                FirstName = customerToUpdate.FirstName,
                LastName = customerToUpdate.LastName,
                Email = customerToUpdate.Email,
                PhoneNumber = customerToUpdate.PhoneNumber,
                Address = customerToUpdate.Address,
                VehicleMake = customerToUpdate.VehicleMake,
            };
        }
        public async Task<bool> DeleteCustomer(int customerId)
        {
            var customerToDelete = await _context.Customers.FindAsync(customerId);

            if (customerToDelete == null)
            {
                return false;
            }

            _context.Customers.Remove(customerToDelete);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<CustomerDto>> GetCustomersWithFilterAndSort(string? filter, string sort)
        {
            var query = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(c => c.FirstName.Contains(filter) || c.LastName.Contains(filter) || c.VehicleMake.Contains(filter));
            }

            if (sort == "desc")
            {
                query = query.OrderByDescending(c => c.LastName);
            }
            else
            {
                query = query.OrderBy(c => c.LastName);
            }

            return await query.Select(c => new CustomerDto
            {
                CustomerId = c.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address,
                VehicleMake = c.VehicleMake,
            })
            .ToListAsync();
        }
    }
}
