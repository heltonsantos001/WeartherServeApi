using System.Text.Json;
using WeartherServeApi.Model;

namespace WeartherServeApi.Service
{
    public class ServiceAirPolution : IServiceAirPolution
    {
        private readonly string  _apiKey = "c773e0683a1b0eb97feec80c561d87ce";

        private readonly HttpClient _client;

        public ServiceAirPolution(HttpClient client)
        {
            this._client = client;
        }

        public async Task<GeoLocationModel> GetLocation(string city)
        {
             string url = $"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit=1&appid={_apiKey}";

            try 
            { 
                HttpResponseMessage response = await _client.GetAsync(url);

                if(!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(jsonResponse))  return null; 

                var geoLocation = JsonSerializer.Deserialize<GeoLocationModel>(jsonResponse);

                if (geoLocation == null) return null;

                return geoLocation;

            } catch (Exception ex) {

                throw new Exception("Erro na requisiçao: ", ex);
            }
        }
    }
}
