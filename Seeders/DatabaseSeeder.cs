using WorkshopBookingSystemWebAPI.Database;

namespace WorkshopBookingSystemWebAPI.Seeders
{
    public class DatabaseSeeder
    {
        private readonly CustomerSeeder _customerSeeder;
        private readonly EmployeeSeeder _employeeSeeder;
        private readonly ServiceTypeSeeder _serviceTypeSeeder;
        private readonly AvailableSlotSeeder _availableSlotSeeder;
        private readonly BookingSeeder _bookingSeeder;

        public DatabaseSeeder(CustomerSeeder customerSeeder,
            EmployeeSeeder employeeSeeder,
            ServiceTypeSeeder serviceTypeSeeder,
            AvailableSlotSeeder availableSlotSeeder,
            BookingSeeder bookingSeeder)
        {
            _customerSeeder = customerSeeder;
            _employeeSeeder = employeeSeeder;
            _serviceTypeSeeder = serviceTypeSeeder;
            _availableSlotSeeder = availableSlotSeeder;
            _bookingSeeder = bookingSeeder;
        }
        public void Seed(WorkshopBookingSystemContext context)
        {
            _serviceTypeSeeder.Seed(context);
            _customerSeeder.Seed(context);
            _employeeSeeder.Seed(context);
            _availableSlotSeeder.Seed(context);
            _bookingSeeder.Seed(context);
        }
    }
}
