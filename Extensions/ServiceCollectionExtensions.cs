using WorkshopBookingSystemWebAPI.Interfaces;
using WorkshopBookingSystemWebAPI.Seeders;
using WorkshopBookingSystemWebAPI.Services;

namespace WorkshopBookingSystemWebAPI.Extensions

{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddScoped<EmployeeSeeder>();
            services.AddScoped<CustomerSeeder>();
            services.AddScoped<BookingSeeder>();
            services.AddScoped<ServiceTypeSeeder>();
            services.AddScoped<AvailableSlotSeeder>();
            services.AddScoped<DatabaseSeeder>();

            return services;
        }
        
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IServiceTypeService, ServiceTypeService>();
            services.AddHttpClient<IVehicleApiService, VehicleApiService>();

            return services;
        }
    }
}
