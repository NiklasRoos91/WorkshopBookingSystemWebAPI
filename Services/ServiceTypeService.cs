using WorkshopBookingSystemWebAPI.Database;
using WorkshopBookingSystemWebAPI.Interfaces;
using WorkshopBookingSystemWebAPI.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WorkshopBookingSystemWebAPI.Models;
using WorkshopBookingSystemWebAPI.Validators;

namespace WorkshopBookingSystemWebAPI.Services
{
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly WorkshopBookingSystemContext _context;
        private readonly ServiceTypeValidator _serviceTypeValidator;

        public ServiceTypeService(WorkshopBookingSystemContext context, ServiceTypeValidator serviceTypeValidator)
        {
            _context = context;
            _serviceTypeValidator = serviceTypeValidator;
        }

        public async Task<List<ServiceTypeDto>> GetAllServiceTypes()
        {
            return await _context.ServiceTypes
                .Select(st => new ServiceTypeDto
                {
                    ServiceTypeId = st.ServiceTypeId,
                    Name = st.Name,
                    Price = st.Price,
                    Duration = st.Duration.ToString()
                })
                .ToListAsync();
        }

        public async Task<ServiceTypeDto?> GetServiceTypeById(int serviceTypeId)
        {
            return await _context.ServiceTypes
                .Where(st => st.ServiceTypeId == serviceTypeId)
                .Select(st => new ServiceTypeDto
                {
                    ServiceTypeId = st.ServiceTypeId,
                    Name = st.Name,
                    Price = st.Price,
                    Duration = st.Duration.ToString()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ServiceTypeInputDto> CreateServiceType(ServiceTypeInputDto serviceType)
        {
            var validationResult = _serviceTypeValidator.Validate(serviceType);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var newServiceType = new ServiceType
            {
                Name = serviceType.Name,
                Price = serviceType.Price,
                Duration = TimeSpan.Parse(serviceType.Duration)
            };

            _context.ServiceTypes.Add(newServiceType);
            await _context.SaveChangesAsync();

            return new ServiceTypeInputDto
            {
                Name = newServiceType.Name,
                Price = newServiceType.Price,
                Duration = newServiceType.Duration.ToString()
            };
        }

        public async Task<ServiceTypeInputDto> UpdateServiceType(int serviceTypeId, ServiceTypeInputDto serviceType)
        {
            var validationResult = _serviceTypeValidator.Validate(serviceType);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            
            var serviceTypeToUpdate = await _context.ServiceTypes.FindAsync(serviceTypeId);

            if (serviceTypeToUpdate == null)
            {
                return null;
            }

            serviceTypeToUpdate.Name = serviceType.Name;
            serviceTypeToUpdate.Price = serviceType.Price;
            serviceTypeToUpdate.Duration = TimeSpan.Parse(serviceType.Duration);

            await _context.SaveChangesAsync();

            return new ServiceTypeInputDto
            {
                Name = serviceTypeToUpdate.Name,
                Price = serviceTypeToUpdate.Price,
                Duration = serviceTypeToUpdate.Duration.ToString()
            };
        }

        public async Task<bool> DeleteServiceType(int serviceTypeId)
        {
            var serviceType = await _context.ServiceTypes.FindAsync(serviceTypeId);
            if (serviceType == null)
            {
                return false;
            }

            _context.ServiceTypes.Remove(serviceType);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
