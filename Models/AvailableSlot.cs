namespace WorkshopBookingSystemWebAPI.Models
{
    public class AvailableSlot
    {
        public int AvailableSlotId { get; set; } 
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; }

        public List<AvailableSlotServiceType> AvailableSlotServiceTypes { get; set; }
    }
}
