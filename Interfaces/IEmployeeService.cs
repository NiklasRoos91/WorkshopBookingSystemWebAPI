using WorkshopBookingSystemWebAPI.DTOs;

namespace WorkshopBookingSystemWebAPI.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDto>> GetAllEmployees();
        public Task<EmployeeDto?> GetEmployeeById(int id);
        public Task<EmployeeInputDto > CreateEmployee(EmployeeInputDto  employee);
        public Task<EmployeeInputDto > UpdateEmployee(int employeeId, EmployeeInputDto  employee);
        public Task<bool> DeleteEmployee(int employeeId);
        public Task<bool> EmployeeExists(int employeeId);
    }
}
