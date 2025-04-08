namespace WorkshopBookingSystemWebAPI.Interfaces
{
    public interface IVehicleApiService
    {
        public Task<List<string>> GetVehicleMakesAsync(CancellationToken cancellationToken);
        public Task LoadVehicleMakesAsync(CancellationToken cancellationToken);
        public Task<bool> DoesVehicleMakeExistAsync(string vehicleMake, CancellationToken cancellationToken);
    }
}
