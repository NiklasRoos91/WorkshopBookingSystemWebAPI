namespace WorkshopBookingSystemWebAPI.Models
{
    public class AvailableSlotServiceType
    {
        public int AvailableSlotServiceTypeId { get; set; }
        public int AvailableSlotId { get; set; }
        public AvailableSlot AvailableSlot { get; set; }

        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
