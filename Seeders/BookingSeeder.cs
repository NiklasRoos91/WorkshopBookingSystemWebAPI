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

                if (employees.Count == 0)
                {
                    throw new InvalidOperationException("No employees found. Seed employees first.");
                }

                if (serviceTypes.Count == 0)
                {
                    throw new InvalidOperationException("No service types found. Seed service types first.");
                }

                if (customers.Count == 0)
                {
                    throw new InvalidOperationException("No customers found. Seed customers first.");
                }

                var bookingFaker = new Faker<Booking>()
                    .RuleFor(b => b.CustomerId, f => f.PickRandom(customers).CustomerId)
                    .RuleFor(a => a.EmployeeId, f => f.PickRandom(employees).EmployeeId)
                    .RuleFor(a => a.ServiceTypeId, (f, a) => a.ServiceType.ServiceTypeId)
                    .RuleFor(b => b.StartTime, f => f.Date.Soon())
                    .RuleFor(b => b.EndTime, (f, b) => b.StartTime.AddMinutes(30));

                context.Bookings.AddRange(bookingFaker.Generate(15));
                context.SaveChanges();
            }
        }
    }
}
