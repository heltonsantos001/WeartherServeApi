using System.Text.Json;
using WeartherServeApi.Model;


namespace WeartherServeApi.Service
{
    public class ServiceWearther : IServiceWearther
    {

        private readonly string ApiKey;

        private readonly HttpClient client;

        public ServiceWearther(HttpClient httpClient, IConfiguration configuration)
        {
            this.client = httpClient;
            this.ApiKey = configuration["WeatherApi:ApiKey"];
        }

        public async Task<ServiceResponse<WeartherMonthModel>> GetWeartherMonthService(string city)
        {
            string url = $"https://pro.openweathermap.org/data/2.5/forecast/climate?q={city}&appid={ApiKey}&units=metric&lang=pt_br";

            ServiceResponse<WeartherMonthModel> response = new();

            try {

                HttpResponseMessage httpResponse = await client.GetAsync(url);

                if(!httpResponse.IsSuccessStatusCode)
                {                  
                    response.Message = $"Not found {httpResponse.RequestMessage}";
                }

                string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                var ApiResponse = JsonSerializer.Deserialize<WeartherMonthModel>(jsonResponse);

                response.Data = ApiResponse;
                response.Success = ApiResponse != null;
                response.Message = ApiResponse != null ? "Weather data retrieved successfully." : "Error deserializing weather data.";

            }
            catch (Exception ex) {

                response.Data = null;          
                response.Message = $"Exception occurred: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<WeartherNowModel>> GetWeartherService(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}&lang=pt_br&units=metric";

            ServiceResponse<WeartherNowModel> response = new();

            try { 

                HttpResponseMessage httpResponse = await client.GetAsync(url);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    response.Data = null;
                    response.Message = $"Error retrieving weather data. Status code: {httpResponse.StatusCode}";
                }
                string jsonResponse = await httpResponse.Content.ReadAsStringAsync();                 

                var ApiResponse = JsonSerializer.Deserialize<WeartherNowModel>(jsonResponse);
                   
                response.Data = ApiResponse;
                response.Success = ApiResponse != null;
                response.Message = ApiResponse != null ? "Weather data retrieved successfully.": "Error deserializing weather data."; 

            }
            catch (Exception ex)
            {               
                response.Message = $"Exception occurred: {ex.Message}";
            }

            return response;
        }

       
    }
}
