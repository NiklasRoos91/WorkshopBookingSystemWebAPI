using WorkshopBookingSystemWebAPI.Interfaces;

namespace WorkshopBookingSystemWebAPI.Validators
{
    public class DataValidator
    {
        private readonly IDataService _dataService;

        public DataValidator(IDataService dataService)
        {
            _dataService = dataService;
        }

        public bool BeAValidEmployee(int employeeId)
        {
            var employees = _dataService.GetListOfExistingEmployees();
            return employees.Any(e => e.EmployeeId == employeeId);
        }

        public bool BeAValidServiceType(int serviceTypeId)
        {
            var serviceTypes = _dataService.GetListOfExistingServiceTypes();
            return serviceTypes.Any(s => s.ServiceTypeId == serviceTypeId);
        }

        public bool BeAValidCustomer(int customerId)
        {
            var customers = _dataService.GetListOfExistingCustomers();
            return customers.Any(c => c.CustomerId == customerId);
        }
    }
}
