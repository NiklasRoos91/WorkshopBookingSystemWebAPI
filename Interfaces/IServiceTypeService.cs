using WorkshopBookingSystemWebAPI.DTOs;

namespace WorkshopBookingSystemWebAPI.Interfaces
{
    public interface IServiceTypeService
    {
        public Task<List<ServiceTypeDto>> GetAllServiceTypes();
        public Task<ServiceTypeDto?> GetServiceTypeById(int id);
        public Task<ServiceTypeInputDto> CreateServiceType(ServiceTypeInputDto serviceType);
        public Task<ServiceTypeInputDto> UpdateServiceType(int serviceTypeId, ServiceTypeInputDto serviceType);
        public Task<bool> DeleteServiceType(int serviceTypeId);


    }
}
