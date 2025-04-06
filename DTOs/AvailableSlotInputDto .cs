using WorkshopBookingSystemWebAPI.Models;

namespace WorkshopBookingSystemWebAPI.DTOs
{
    public class AvailableSlotInputDto
    {
        public int EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ServiceTypeId { get; set; }
    }
}
