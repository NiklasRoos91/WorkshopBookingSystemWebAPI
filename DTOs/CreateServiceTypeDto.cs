﻿namespace WorkshopBookingSystemWebAPI.DTOs
{
    public class CreateServiceTypeDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
