using Bogus;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WorkshopBookingSystemWebAPI.Database;
using WorkshopBookingSystemWebAPI.Models;

namespace WorkshopBookingSystemWebAPI.Seeders
{
    public class EmployeeSeeder
    {
        public void Seed(WorkshopBookingSystemContext context)
        {
            if (!context.Employees.Any())
            {
                var employeeFaker = new Faker<Employee>()
                    .RuleFor(e => e.FirstName, f => f.Name.FirstName())
                    .RuleFor(e => e.LastName, f => f.Name.LastName())
                    .RuleFor(e => e.PhoneNumber, f => f.Phone.PhoneNumber())
                    .RuleFor(E => E.Email, f => f.Internet.Email());

                context.Employees.AddRange(employeeFaker.Generate(6));
                context.SaveChanges();
            }
        }

    }
}
