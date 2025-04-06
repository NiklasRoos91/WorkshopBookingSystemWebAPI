﻿namespace WorkshopBookingSystemWebAPI.DTOs
{
    public class ServiceTypeInputDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; } // "HH:mm:ss"
    }
}
