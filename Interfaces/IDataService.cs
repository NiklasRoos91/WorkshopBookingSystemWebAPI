using WorkshopBookingSystemWebAPI.Models;

namespace WorkshopBookingSystemWebAPI.Interfaces
{
    public interface IDataService
    {
        List<Employee> GetListOfExistingEmployees();
        List<ServiceType> GetListOfExistingServiceTypes();
        List<Customer> GetListOfExistingCustomers();
    }
}
