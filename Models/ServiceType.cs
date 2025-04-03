namespace WorkshopBookingSystemWebAPI.Models
{
    public class ServiceType
    {
        public int ServiceTypeId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
