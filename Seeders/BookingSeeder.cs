using Bogus;
using WorkshopBookingSystemWebAPI.Database;
using WorkshopBookingSystemWebAPI.Models;

namespace WorkshopBookingSystemWebAPI.Seeders
{
    public class BookingSeeder
    {
        public void Seed(WorkshopBookingSystemContext context)
        {
            if (!context.Bookings.Any())
            {
                var customers = context.Customers.ToList();
                var employees = context.Employees.ToList();
                var serviceTypes = context.ServiceTypes.ToList();

                var bookingFaker = new Faker<Booking>()
                    .RuleFor(b => b.CustomerId, f => f.PickRandom(customers).CustomerId)
                    .RuleFor(a => a.EmployeeId, f => f.PickRandom(employees).EmployeeId)
                    .RuleFor(b => b.ServiceTypeId, f => f.PickRandom(serviceTypes).ServiceTypeId)
                    .RuleFor(b => b.StartTime, f => f.Date.Soon())
                    .RuleFor(b => b.EndTime, (f, b) => b.StartTime.AddMinutes(30));

                context.Bookings.AddRange(bookingFaker.Generate(15));
                context.SaveChanges();
            }
        }
    }
}
