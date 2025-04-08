using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WorkshopBookingSystemWebAPI.Interfaces;
using System.Threading;

namespace WorkshopBookingSystemWebAPI.Services
{
    public class VehicleApiService : IVehicleApiService
    {
        private readonly HttpClient _httpClient;
        private List<string> _cachedMakes;
        private bool _dataLoaded = false;

        public VehicleApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<string>> GetVehicleMakesAsync(CancellationToken cancellationToken)
        {
            if (!_dataLoaded)
            {
                await LoadVehicleMakesAsync(cancellationToken);
            }

            return _cachedMakes;
        }

        public async Task LoadVehicleMakesAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetStringAsync("https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json", cancellationToken);
            var jsonResponse = JsonConvert.DeserializeObject<JObject>(response);

            _cachedMakes = jsonResponse["Results"]
            .Select(m => m["Make_Name"].ToString())
            .ToList();

            _dataLoaded = true;
        }

        public async Task<bool> DoesVehicleMakeExistAsync(string vehicleMake, CancellationToken cancellationToken)
        {
            if (!_dataLoaded)
            {
                await LoadVehicleMakesAsync(cancellationToken);
            }

            return _cachedMakes.Contains(vehicleMake, StringComparer.OrdinalIgnoreCase);
        }
    }
}
