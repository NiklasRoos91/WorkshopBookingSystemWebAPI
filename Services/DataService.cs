using WorkshopBookingSystemWebAPI.Database;
using WorkshopBookingSystemWebAPI.Interfaces;
using WorkshopBookingSystemWebAPI.Models;

namespace WorkshopBookingSystemWebAPI.Services
{
    public class DataService : IDataService
    {
        private readonly WorkshopBookingSystemContext _context;

        public DataService(WorkshopBookingSystemContext context)
        {
            _context = context;
        }

        public List<Employee> GetListOfExistingEmployees()
        {
            var employees = _context.Employees.ToList();

            if (employees.Count == 0)
            {
                throw new InvalidOperationException("No employees found. Seed employees first.");
            }
            return employees;
        }

        public List<Customer> GetListOfExistingCustomers()
        {
            var customers = _context.Customers.ToList();

            if (customers.Count == 0)
            {
                throw new InvalidOperationException("No customers found. Seed customers first.");
            }
            return customers;
        }

        public List<ServiceType> GetListOfExistingServiceTypes()
        {
            var serviceTypes = _context.ServiceTypes.ToList();

            if (serviceTypes.Count == 0)
            {
                throw new InvalidOperationException("No service types found. Seed service types first.");
            }
            return serviceTypes;
        }

        public List<Booking> GetListOfExistingBookings()
        {
            return _context.Bookings.ToList();
        }

        public List<AvailableSlot> AvailableSlots()
        {
            return _context.AvailableSlots.ToList();
        }
    }
}
