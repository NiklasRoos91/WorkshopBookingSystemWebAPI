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
        public DbSet<AvailableSlotServiceType> AvailableSlotServiceTypes { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definiera många-till-många-relationen mellan AvailableSlot och ServiceType
            modelBuilder.Entity<AvailableSlotServiceType>()
                .HasKey(ass => new { ass.AvailableSlotId, ass.ServiceTypeId });

            modelBuilder.Entity<AvailableSlotServiceType>()
                .HasOne(ass => ass.AvailableSlot)
                .WithMany(slot => slot.AvailableSlotServiceTypes)
                .HasForeignKey(ass => ass.AvailableSlotId);

            modelBuilder.Entity<AvailableSlotServiceType>()
                .HasOne(ass => ass.ServiceType)
                .WithMany()
                .HasForeignKey(ass => ass.ServiceTypeId);

            modelBuilder.Entity<ServiceType>()
                .Property(s => s.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
