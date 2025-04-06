using WorkshopBookingSystemWebAPI.DTOs;

namespace WorkshopBookingSystemWebAPI.Interfaces
{
    public interface ICustomerService
    {
        public Task<List<CustomerDto>> GetAllCustomers();
        public Task<CustomerDto?> GetCustomersById(int customerId);
        public Task<CustomerInputDto > CreateCustomer(CustomerInputDto  customer);
        public Task<CustomerInputDto > UpdateCustomer(int customerId, CustomerInputDto  customer);
        public Task<bool> DeleteCustomer(int customerId);
    }
}
