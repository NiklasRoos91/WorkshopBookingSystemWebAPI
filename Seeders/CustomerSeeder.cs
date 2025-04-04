using WorkshopBookingSystemWebAPI.Database;
using Bogus;
using WorkshopBookingSystemWebAPI.Models;

namespace WorkshopBookingSystemWebAPI.Seeders
{
    public class CustomerSeeder
    {
        public void Seed(WorkshopBookingSystemContext context)
        {
            if (!context.Customers.Any())
            {
                var customerFaker = new Faker<Customer>()
                    .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                    .RuleFor(c => c.LastName, f => f.Name.LastName())
                    .RuleFor(c => c.Address, f => f.Address.FullAddress())
                    .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber())
                    .RuleFor(c => c.Email, f => f.Internet.Email())
                    .RuleFor(c => c.VehicleMake, f => f.Vehicle.Manufacturer());

                context.Customers.AddRange(customerFaker.Generate(20));
                context.SaveChanges();
            }
        }
    }
}
