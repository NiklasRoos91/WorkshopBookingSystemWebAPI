using Bogus;
using System.Drawing.Text;
using WorkshopBookingSystemWebAPI.Database;
using WorkshopBookingSystemWebAPI.Models;

namespace WorkshopBookingSystemWebAPI.Seeders
{
    public class AvailableSlotSeeder
    {
        public void Seed(WorkshopBookingSystemContext context)
        {
            
            if (!context.AvailableSlots.Any())
            {
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

                var availableSlotFaker = new Faker<AvailableSlot>()
                    .RuleFor(a => a.EmployeeId, f => f.PickRandom(employees).EmployeeId)
                    .RuleFor(a => a.StartTime, f => f.Date.Soon())
                    .RuleFor(a => a.EndTime, (f, a) => a.StartTime.AddMinutes(30))
                    .RuleFor(a => a.IsAvailable, f => true)
                    .RuleFor(a => a.ServiceType, f => f.PickRandom(serviceTypes))
                    .RuleFor(a => a.ServiceTypeId, (f, a) => a.ServiceType.ServiceTypeId);

                context.AvailableSlots.AddRange(availableSlotFaker.Generate(20));
                context.SaveChanges();
            }
        }
    }
}
