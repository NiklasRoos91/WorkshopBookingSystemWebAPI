using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WorkshopBookingSystemWebAPI.Database;
using WorkshopBookingSystemWebAPI.Extensions;
using WorkshopBookingSystemWebAPI.Seeders;
using WorkshopBookingSystemWebAPI.Validators;

namespace WorkshopBookingSystemWebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<WorkshopBookingSystemContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("WorkshopBookingSystemWebAPIDatabase")));

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSeeders();
        builder.Services.AddApplicationServices();
        builder.Services.AddScoped<DataValidator>();


        builder.Services.AddValidatorsFromAssemblyContaining<AvailableSlotValidator>();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
            var context = scope.ServiceProvider.GetRequiredService<WorkshopBookingSystemContext>();
            seeder.Seed(context);
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
