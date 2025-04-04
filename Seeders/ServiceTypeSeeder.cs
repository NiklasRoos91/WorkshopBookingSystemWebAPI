using Bogus;
using WorkshopBookingSystemWebAPI.Database;
using WorkshopBookingSystemWebAPI.Models;

namespace WorkshopBookingSystemWebAPI.Seeders
{
    public class ServiceTypeSeeder
    {
        public void Seed(WorkshopBookingSystemContext context)
        {
            if (!context.ServiceTypes.Any())
            {
                var serviceTypes = new List<ServiceType>
                {
                    new ServiceType { Name = "Oil Change" },
                    new ServiceType { Name = "Brake Inspection" },
                    new ServiceType { Name = "Tire Rotation" },
                    new ServiceType { Name = "Battery Replacement" },
                    new ServiceType { Name = "Wheel Alignment" },
                    new ServiceType { Name = "Engine Diagnostics" },
                    new ServiceType { Name = "Transmission Repair" },
                    new ServiceType { Name = "Suspension Repair" },
                    new ServiceType { Name = "AC System Recharge" },
                    new ServiceType { Name = "Timing Belt Replacement" }
                };

                context.ServiceTypes.AddRange(serviceTypes);
                context.SaveChanges();
            }
        }
    }
}
