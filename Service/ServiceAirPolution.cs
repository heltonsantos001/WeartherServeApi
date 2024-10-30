using System.Text.Json;
using WeartherServeApi.Model;

namespace WeartherServeApi.Service
{
    public class ServiceAirPolution : IServiceAirPolution
    {
        private string _apiKey;

        private readonly HttpClient _client;

        public ServiceAirPolution(HttpClient client, IConfiguration configuration)
        {
            this._client = client;
            this._apiKey = configuration["WeatherApi:ApiKey"];
        }

        public async Task<ServiceResponse<AirPolutionModel>> GetAirPolution(string city)
        {
            ServiceResponse<AirPolutionModel> response = new();
            try {

                List<GeoLocationModel> geoLocation = await GetLocation(city);

                if (geoLocation == null || !geoLocation.Any()) return null;

                var lat = geoLocation[0].Lat;
                var lon = geoLocation[0].Lon;

                string url = $"http://api.openweathermap.org/data/2.5/air_pollution?lat={lat}&lon={lon}&appid={this._apiKey}";
                HttpResponseMessage Httpresponse = await _client.GetAsync(url);

                if (!Httpresponse.IsSuccessStatusCode) {
                    response.Message = $"City not found!. {Httpresponse.RequestMessage}";
                    return response;
                } 

                string jsonResponse = await Httpresponse.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(jsonResponse))
                {
                    response.Message = "not found";

                    return response;
                }

                var airPolution = JsonSerializer.Deserialize<AirPolutionModel>(jsonResponse);

                response.Data = airPolution;
                response.Success = true;
                response.Message = "Success";

                return response;
            } 
            catch (Exception ex) 
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<List<GeoLocationModel>> GetLocation(string city)
        {
             string url = $"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit=1&appid={_apiKey}";

            try 
            { 
                HttpResponseMessage response = await this._client.GetAsync(url);

                if(!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Not Found: {response.StatusCode}");
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(jsonResponse))  return null; 

                var geoLocation = JsonSerializer.Deserialize<List<GeoLocationModel>>(jsonResponse);

                if (geoLocation == null) return null;

                return geoLocation;

            } catch (Exception ex) {

                throw new Exception("Error: ", ex);
            }
        }
    }
}
