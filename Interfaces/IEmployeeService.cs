using WorkshopBookingSystemWebAPI.DTOs;

namespace WorkshopBookingSystemWebAPI.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDto>> GetAllEmployees();
        public Task<EmployeeDto?> GetEmployeeById(int id);
        public Task<CreateEmployeeDto> CreateEmployee(CreateEmployeeDto employee);
        public Task<CreateEmployeeDto> UpdateEmployee(int employeeId, CreateEmployeeDto employee);
        public Task<bool> DeleteEmployee(int employeeId);
        public Task<bool> EmployeeExists(int employeeId);
    }
}
