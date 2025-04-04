using Microsoft.EntityFrameworkCore;
using WorkshopBookingSystemWebAPI.Models;

namespace WorkshopBookingSystemWebAPI.Database
{
    public class WorkshopBookingSystemContext : DbContext
    {
        public WorkshopBookingSystemContext(DbContextOptions<WorkshopBookingSystemContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<AvailableSlot> AvailableSlots { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AvailableSlot>()
              .HasOne(a => a.ServiceType)   // Varje AvailableSlot har en ServiceType
              .WithMany()                   // Ingen referens tillbaka
              .HasForeignKey(a => a.ServiceTypeId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServiceType>()
                .Property(s => s.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
